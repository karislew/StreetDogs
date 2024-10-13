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
    public GameObject churroLocation;
    //private DialogueTrigger dialogueTrigger;

    //not the best way to do this, but I want it to seem like the dog
    //gets an existing churro - Rafa
    public GameObject churroSprite;

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
            rb.velocity = new Vector3(5f, 0, 0);
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
        completeTask();
        taskIcon.color = new Color(1, 1, 1, 0);
        //Increment player's task count when they've been done CORRECTLY (public opinion counter kinda)
        player.tasksCompleted++;
        //NPC has done an action and cannot be interacted with anymore
        hasDoneAction = true;
        canBeInteracted = false;
        //dialogueTrigger.TriggerDialogue("Bark");

        Destroy(churroSprite);
    }
    public override void onBeg()
    {
        base.onBeg();

        //Spawns churro and correctly completes task
        Instantiate(churro, churroLocation.transform.position, Quaternion.identity);
        completeTask();
        taskIcon.color = new Color(1, 1, 1, 0);
        player.tasksCompleted++;
        hasDoneAction = true;
        canBeInteracted = false;

        // delete existing in-scene churro
        Destroy(churroSprite);
        //dialogueTrigger.TriggerDialogue("Beg");
    }
    public override void onGrowl()
    {
        base.onGrowl();
        //Runs away and fails task
        shouldRun = true;
        completeTask();
        taskIcon.color = new Color(1, 1, 1, 0);
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
