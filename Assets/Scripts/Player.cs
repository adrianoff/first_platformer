using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private Collider2D collider2d;

    public Transform groundCheck;

    public AudioSource hitSound;
    public AudioSource hpUpSound;
    public Main main;

    public float speed;
    public float jumpHeight;

    private bool isGrounded = true;

    private bool isHit = false;

    private int maxHp = 10;
    private int curHp = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2d = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        checkGround();
        rb.velocity = new UnityEngine.Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Horizontal") == 0 && isGrounded) {
            animator.SetInteger("state", 1);
        } else if (!isGrounded) {
            animator.SetInteger("state", 3);
        } else {
            animator.SetInteger("state", 2);
        }
    }

    void FixedUpdate() 
    {
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0 ) {
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0 ) {
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 180, 0);
        }
    }

    void checkGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }

    public void removeAllHP()
    {
        RecountHP(-curHp);
    }

    public void RecountHP(int deltaHp)
    {
        curHp += deltaHp;

        if (deltaHp < 0) {
            StopCoroutine(OnHit());
            isHit = true;
            hitSound.Play();
            StartCoroutine(OnHit());
        } else {
            if (curHp > maxHp) {
                curHp = maxHp;
            }
        }

        if (curHp <= 0) {
            // Dead animation
            collider2d.enabled = false;
            Invoke("Lose", 1.5f);
        }
    }

    IEnumerator OnHit() 
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (isHit) {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
        } else {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);
        }

        if (GetComponent<SpriteRenderer>().color.g <= 1f) {
            StopCoroutine(OnHit());
        }

        if (GetComponent<SpriteRenderer>().color.g <= 0) {
            isHit = false;
        }

        yield return new WaitForSeconds(0.02f);
        StartCoroutine(OnHit());
    }

    public void Lose()
    {
        main.GetComponent<Main>().Lose();
    }
}