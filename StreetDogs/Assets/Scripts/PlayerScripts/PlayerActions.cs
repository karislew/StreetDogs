using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    private AudioSource audioPlayer;
    
    public Interactable interactionTarget = null;

    public Image emotion;
    //Index 0 is BARK, Index 1 is GROWL, Index 2 is BEG
    public Sprite[] emotionTextures;

    public SpriteRenderer speechBubble;
    //Index 0 is BARK, Index 1 is GROWL, Index 2 is BEG
    public Sprite[] bubbleTextures;

    //Public opinion counter
    public int tasksCompleted = 0;

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
            //set speech bubble and emotion
            emotion.sprite = emotionTextures[0];
            speechBubble.sprite = bubbleTextures[0];
            StartCoroutine(AnimateBubbleAndEmotion());
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
            emotion.sprite = emotionTextures[1];
            speechBubble.sprite = bubbleTextures[1];
            StartCoroutine(AnimateBubbleAndEmotion());
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
            emotion.sprite = emotionTextures[2];
            speechBubble.sprite = bubbleTextures[2];
            StartCoroutine(AnimateBubbleAndEmotion());
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
            emotion.sprite = emotionTextures[3];
            speechBubble.sprite = null;
            StartCoroutine(AnimateBubbleAndEmotion());
            if (interactionTarget != null && interactionTarget.canBeInteracted)
            {
                interactionTarget.onInteract();
              
            }
        }
    }

    //------------------------------

    IEnumerator AnimateBubbleAndEmotion()
    {
        speechBubble.enabled = true;
        yield return new WaitForSeconds(1.5f);
        speechBubble.enabled = false;
        //3 is default
        emotion.sprite = emotionTextures[3];
    }

}
