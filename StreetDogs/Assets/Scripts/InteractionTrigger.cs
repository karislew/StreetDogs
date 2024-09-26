using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{

    public PlayerActions player;

    private Interactable target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Interactable>() != null)
        {
            print("HIT");
            target = collision.GetComponent<Interactable>();
            player.interactionTarget = target;
            target.canBeInteracted = true;
        }
    }

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
