using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagedDog : Interactable
{
    public DogWardenNPC warden;
    public GameObject cage;
    public bool hasKey = false;
    
    private void Awake()
    {
        //Uses behavior from parent class, with additional code
        base.Awake();
    }

    //Makes character run away and disappear for Growl interaction
    private void Update()
    {
        base.Update();
    }

    public override void onBark()
    {
        completeTask(Color.clear);
        //START BARKING
        warden.shouldMoveLeft = true;
        warden.shouldDropKey = true;
    }
    public override void onBeg()
    {
        //No behavior
        completeTask(Color.clear);
    }
    public override void onGrowl()
    {
        completeTask(Color.clear);
        //START BARKING
        warden.shouldMoveLeft = true;
        warden.shouldDropKey = true;
    }
    public override void onInteract()
    {
        if (hasKey)
        {
            newCurrentTaskText = "";
            player.tasksCompleted++;
            completeTask(Color.green);
            hasDoneAction = true;
            canBeInteracted = false;
            Destroy(cage);
        }
        else
        {
            completeTask(Color.clear);
        }
    }
}
