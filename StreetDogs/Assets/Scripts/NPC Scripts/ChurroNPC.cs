using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChurroNPC : Interactable
{

    //See how this class inherits from Interactable ^^^

    public GameObject churro;
    private bool shouldRun = false;
    private Rigidbody2D rb;
    //private DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        //Uses behavior from parent class, with additional code
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        //dialogueTrigger = GetComponent<DialogueTrigger>(); 
    }

    //Makes character run away and disappear for Growl interaction
    private void Update()
    {
        base.Update();
        if (shouldRun)
        {
            rb.velocity = new Vector3(10f, 0, 0);
        }
        if(transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }

    //Needs override keyword to create unique behavior
    public override void onBark()
    {
        base.onBark();
        
        //Spawns churro and correctly completes task
        Instantiate(churro, gameObject.transform.position, Quaternion.identity);
        completeTask(Color.green);
        //Increment player's task count when they've been done CORRECTLY (public opinion counter kinda)
        player.tasksCompleted++;
        //NPC has done an action and cannot be interacted with anymore
        hasDoneAction = true;
        canBeInteracted = false;
        //dialogueTrigger.TriggerDialogue("Bark");
    }
    public override void onBeg()
    {
        base.onBeg();

        //Spawns churro and correctly completes task
        Instantiate(churro, gameObject.transform.position, Quaternion.identity);
        completeTask(Color.green);
        player.tasksCompleted++;
        hasDoneAction = true;
        canBeInteracted = false;
        //dialogueTrigger.TriggerDialogue("Beg");
    }
    public override void onGrowl()
    {
        base.onGrowl();
        //Runs away and fails task
        shouldRun = true;
        completeTask(Color.red);
        hasDoneAction = true;
        canBeInteracted = false;
       // dialogueTrigger.TriggerDialogue("Growl");
    }
    public override void onInteract()
    {
        base.onInteract();
        Debug.Log("The Z trigger is working");
        //dialogueTrigger.TriggerDialogue("Interact");

       //SHOO ANIMATION
    }
}
