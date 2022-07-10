using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource collectSound;

    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") {
            collectSound.Play();
        }

        this.gameObject.SetActive(false);
    }
}
