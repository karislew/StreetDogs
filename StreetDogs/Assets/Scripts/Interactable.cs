using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool canBeInteracted;
    public SpriteRenderer signal;

    public void Awake()
    {
        signal = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (canBeInteracted)
        {
            signal.enabled = true;
        }
        else
        {
            signal.enabled = false;
        }
    }

    public virtual void onBark()
    {}

    public virtual void onGrowl()
    {}
   
    public virtual void onBeg()
    {}

    public virtual void onInteract()
    {}
}
