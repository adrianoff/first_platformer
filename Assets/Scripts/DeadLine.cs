using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Player>().removeAllHP();
        }
    }
}
