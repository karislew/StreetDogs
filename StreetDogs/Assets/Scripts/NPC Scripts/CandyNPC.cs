using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyNPC : Interactable
{
    public GameObject candy;
    public bool hasAirhorn;
    private bool hasUpdated;

    private void Awake()
    {
        base.Awake();
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
            //Pet player
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
            //Think about airhorn
            completeTask(Color.clear);
        }
    }
}
