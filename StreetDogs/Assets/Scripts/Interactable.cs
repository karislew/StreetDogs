using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    //PARENT INTERACTABLE OBJECT CLASS, MAKE CHILD CLASSES OF THIS FOR UNIQUE OBJECTS

    public bool canBeInteracted;
    public bool hasDoneAction;
    public SpriteRenderer signal;
    public Image taskIcon;
    public Sprite newTaskIcon;
    //Increment player's task count when they've been done CORRECTLY (see ChurroNPC)
    public PlayerActions player;
    protected DialogueTrigger dialogueTrigger;
    
    //Grabs exclamation point sprite and UI elements
    public void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        signal = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        taskIcon = GameObject.FindGameObjectWithTag("CompletionIndicator").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>();
    }

    //Updates to let player know they are in range of interaction...
    public void Update()
    {
        //...only if they can be interacted with!
        if (canBeInteracted)
        {
            signal.enabled = true;
        }
        else
        {
            signal.enabled = false;
        }
    }
    protected void TriggerDialogue(string actionType)
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue(actionType);
        }
    }

    //DEFAULT BEHAVIORS, EDIT IN CHILD CLASSES

    public virtual void onBark()
    {
       
        TriggerDialogue("Bark");
       
    }
    public virtual void onGrowl()
    {TriggerDialogue("Growl");}
    public virtual void onBeg()
    {TriggerDialogue("Beg");}
    public virtual void onInteract()
    {TriggerDialogue("Interact");}
    
    //Green for CORRECT COMPLETION, Red for FAILED TASK
    public void completeTask()
    {
        taskIcon.color = new Color(1, 1, 1, 1);
        taskIcon.sprite = newTaskIcon;
    }

}
