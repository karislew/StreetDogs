using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private AudioSource audioPlayer;

    //Index 0 is BARK, Index 1 is GROWL, Index 2 is BEG
    public AudioClip[] soundEffects;

    private void Awake()
    {
        //Grabs audio source component
        audioPlayer = GetComponent<AudioSource>();
    }
    public void Bark(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("BARK");
            //Random pitch for variance
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[0];
            audioPlayer.Play();
        }
    }

    public void Growl(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("GROWL");
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[1];
            audioPlayer.Play();
        }
    }

    public void Beg(InputAction.CallbackContext context)
    {
        if (context.performed) 
        { 
            Debug.Log("BEG");
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[2];
            audioPlayer.Play();
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("INTERACT");
        }
    }
}
