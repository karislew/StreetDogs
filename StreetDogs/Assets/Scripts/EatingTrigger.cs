using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EatingTrigger : MonoBehaviour
{

    public PlayerActions player;
    public AudioClip eatSound;

    private AudioSource audioPlayer;

    //Grabs audio component for eating sound
    private void Awake()
    {
        audioPlayer = player.gameObject.GetComponent<AudioSource>();
    }

    //Eats anything tagged as food
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = eatSound;
            audioPlayer.Play();
            Destroy(collision.gameObject);
        }
    }

}
