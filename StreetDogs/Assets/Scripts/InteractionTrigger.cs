using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{

    public PlayerActions player;

    private Interactable target;

    //Sets target as interactable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            print("HIT");
            target = collision.GetComponent<Interactable>();
            player.interactionTarget = target;
            //If interactable has already performed an action, they cannot be interacted with again.
            if(target.hasDoneAction == false)
            {
                target.canBeInteracted = true;
            }
        }
    }

    //Un-sets target as interactable
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            print("GONE");
            target = collision.GetComponent<Interactable>();
            player.interactionTarget = null;
            target.canBeInteracted = false;
        }
    }
}
