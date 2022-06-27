using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        print("TEST");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void FixedUpdate() 
    {
        rb.velocity = new UnityEngine.Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) {
            print("JUMP");
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
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
}
