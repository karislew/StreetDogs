using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWardenNPC : Interactable
{
    public GameObject key;
    public CagedDog cagedDog;
    public bool shouldMoveLeft = false;
    private bool shouldMoveRight = false;
    public bool shouldDropKey = false;
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
        if (shouldMoveLeft)
        {
            rb.velocity = new Vector3(-2.5f, 0, 0);
            if(transform.position.x <= 35)
            {
                shouldMoveLeft = false;
                rb.velocity = Vector3.zero;
            }
        }
        if(shouldMoveRight)
        {
            rb.velocity = new Vector3(10f, 0, 0);
        }
        if(transform.position.x >= 45)
        {
            Destroy(gameObject);
        }
    }

    public override void onBark()
    {
        //SHOO ANIMATION
    }
    public override void onBeg()
    {
        //SHOO ANIMATION
    }
    public override void onGrowl()
    {
        if (shouldDropKey)
        {
            shouldMoveLeft = false;
            Instantiate(key, gameObject.transform.position, Quaternion.identity);
            shouldMoveRight = true;
            cagedDog.hasKey = true;
            hasDoneAction = true;
            canBeInteracted = false;
        }
    }
    public override void onInteract()
    {
        //No interaction
    }
}
