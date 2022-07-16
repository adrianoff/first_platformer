using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) 
    {
        print("TEST");
        if(other.gameObject.tag == "Player") {
            print("TEST");
            other.gameObject.GetComponent<Player>().removeAllHP();
        }
    }
}
