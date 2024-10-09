using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefNPC : Interactable
{
    public GameObject airhorn;
    public CandyNPC candySeller;
    private bool shouldRun = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        //Uses behavior from parent class, with additional code
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    //Makes character run away and disappear for Growl interaction
    private void Update()
    {
        base.Update();
        if (shouldRun)
        {
            rb.velocity = new Vector3(10f, 0, 0);
        }
        if (transform.position.x >= 35)
        {
            Destroy(gameObject);
        }
    }

    public override void onBark()
    {
        base.onBark();
        //SHOO ANIMATION
    }
    public override void onBeg()
    {
        base.onBeg();
        //No behavior
    }
    public override void onGrowl()
    {
        base.onGrowl();
        //Runs away and fails task
        Instantiate(airhorn, gameObject.transform.position, Quaternion.identity);
        candySeller.hasAirhorn = true;
        shouldRun = true;
        completeTask(Color.clear);
        hasDoneAction = true;
        canBeInteracted = false;
    }
    public override void onInteract()
    {
        base.onInteract();
        //Wrestle animation
    }
}
