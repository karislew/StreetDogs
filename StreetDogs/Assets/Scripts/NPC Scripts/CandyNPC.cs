using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyNPC : Interactable
{
    public GameObject candy;
    public bool hasAirhorn;
    private bool hasUpdated;

    //different dialogues based on interaction (could also do a switch case)
    public Dialogue barkdialogue;
    public Dialogue interactdialogue;
    public Dialogue begdialogue;
    public Dialogue growldialogue;


    public GameObject npcDialogueBox;
    public TMP_Text npcDialogueText;
    private DialogueManager dialogueManager;

    Dialogue dialogueToTrigger = null;
 
    

    private void Awake()
    {
        base.Awake();
        dialogueManager= FindObjectOfType<DialogueManager>();
        
    }

    public override void onBark()
    {


        if (hasAirhorn)
        {
            base.onBark();
            newCurrentTaskText = "";
            Instantiate(candy, gameObject.transform.position, Quaternion.identity);
            if (hasUpdated == false)
            {
                completeTask(Color.green);
                player.tasksCompleted++;
                hasUpdated = true;
            }
        }
        else
        {
            NoAirHorn(barkdialogue);
            //Think about airhorn
            completeTask(Color.clear);
        }
    }
    public override void onBeg()
    {


        if (hasAirhorn)
        {
            base.onBeg();
            newCurrentTaskText = "";
            Instantiate(candy, gameObject.transform.position, Quaternion.identity);
            if (hasUpdated == false)
            {
                completeTask(Color.green);
                player.tasksCompleted++;
                hasUpdated = true;
            }
        }
        else
        {
           
            NoAirHorn(begdialogue);
            //Think about airhorn
            completeTask(Color.clear);
        }
    }
    public override void onGrowl()
    {

        if (hasAirhorn)
        {
            base.onGrowl();
            newCurrentTaskText = "";
            Instantiate(candy, gameObject.transform.position, Quaternion.identity);
            if (hasUpdated == false)
            {
                completeTask(Color.green);
                player.tasksCompleted++;
                hasUpdated = true;
            }
        }
        else
        {
            
            NoAirHorn(growldialogue);
            //Think about airhorn
            completeTask(Color.clear);
        }
    }
    public override void onInteract()
    {

        
        if (hasAirhorn)
        {
            base.onInteract();
            
            newCurrentTaskText = "";
            Instantiate(candy, gameObject.transform.position, Quaternion.identity);
            if (hasUpdated == false)
            {
                completeTask(Color.green);
                player.tasksCompleted++;
                hasUpdated = true;
            }
        }
        else
        {
      
            NoAirHorn(interactdialogue);
            //Think about airhorn
            completeTask(Color.clear);
        }
    }
    private void NoAirHorn(Dialogue chosenDialogue)
    {
        dialogueToTrigger = chosenDialogue;
        dialogueManager.StartDialogue(dialogueToTrigger,npcDialogueBox,npcDialogueText);

    }
}
