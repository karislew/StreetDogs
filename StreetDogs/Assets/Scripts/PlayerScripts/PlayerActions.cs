using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private AudioSource audioPlayer;
    
    public Interactable interactionTarget = null;

    //Index 0 is BARK, Index 1 is GROWL, Index 2 is BEG
    public AudioClip[] soundEffects;

    private void Awake()
    {
        //Grabs audio source component
        audioPlayer = GetComponent<AudioSource>();
    }

    //---------- ALL ACTIONS ----------
    //Calls respective functions from target interactable object

    public void Bark(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("BARK");
            //Random pitch for variance
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[0];
            audioPlayer.Play();
            if (interactionTarget != null && interactionTarget.canBeInteracted)
            {
                interactionTarget.onBark();
            }
        }
    }

    public void Growl(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("GROWL");
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[1];
            audioPlayer.Play();
            if (interactionTarget != null && interactionTarget.canBeInteracted)
            {
                interactionTarget.onGrowl();
            }
        }
    }

    public void Beg(InputAction.CallbackContext context)
    {
        if (context.performed) 
        { 
            //Debug.Log("BEG");
            audioPlayer.pitch = Random.Range(.75f, 1.25f);
            audioPlayer.clip = soundEffects[2];
            audioPlayer.Play();
            if (interactionTarget != null && interactionTarget.canBeInteracted)
            {
                interactionTarget.onBeg();
            }
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("INTERACT");
            //No sound plays for this one
            if (interactionTarget != null && interactionTarget.canBeInteracted)
            {
                interactionTarget.onInteract();
            }
        }
    }

    //------------------------------

}
