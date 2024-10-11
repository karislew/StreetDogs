using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    //public string name;
    //public Animator animator;
    public GameObject npcDialogueBox;
    public TMP_Text npcDialogueText;
    public Dialogue barkDialogue;
    public Dialogue growlDialogue;
    public Dialogue interactDialogue;
    public Dialogue begDialogue;  // Ensure this is set in the Inspector

    public void TriggerDialogue(string action)
    {
  
        Dialogue dialogueToTrigger = null;
        switch (action)
        {
            case "Bark": 
                dialogueToTrigger = barkDialogue;
                break;
            case "Beg": 
                dialogueToTrigger = begDialogue;
                break;

            case "Growl": 
                dialogueToTrigger = growlDialogue;
                break;
            case "Interact": 
                dialogueToTrigger = interactDialogue;
                break;
            default:
                break;
        }
        if (dialogueToTrigger != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueToTrigger,npcDialogueBox,npcDialogueText);
            
        }
    }
  

    /*
    // Start is called before the first frame update
    public Dialogue dialogue;

    public Dialogue barkDialogue;
    public Dialogue growlDialogue;
    public Dialogue interactDialogue;
    public Dialogue begDialogue;

    

    
    public void TriggerDialogue(string action)
    {
        Dialogue dialogueToTrigger = null;
        switch (action)
        {
            case "Bark": 
                dialogueToTrigger = barkDialogue;
                break;
            case "Beg": 
                dialogueToTrigger = begDialogue;
                break;
            case "Growl": 
                dialogueToTrigger = growlDialogue;
                break;
            case "Interact": 
                dialogueToTrigger = interactDialogue;
                break;
            default:
                break;
        }

        if (dialogueToTrigger != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueToTrigger);
        }

       
    }
    */
}
