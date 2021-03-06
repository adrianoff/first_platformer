using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse);
            other.gameObject.GetComponent<Player>().RecountHP(-1);
        }
    }
}
