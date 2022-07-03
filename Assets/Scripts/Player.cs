using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public Transform groundCheck;

    public float speed;
    public float jumpHeight;

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
}