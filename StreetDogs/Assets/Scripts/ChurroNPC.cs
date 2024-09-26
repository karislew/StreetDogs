using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChurroNPC : Interactable
{
    public GameObject textBubble;

    private void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        base.Update();
    }

    public override void onBark()
    {
        textBubble.GetComponent<TextMeshPro>().text = "Eeek!";
    }
    public override void onBeg()
    {
        textBubble.GetComponent<TextMeshPro>().text = "Wanna treat?";
    }
    public override void onGrowl()
    {
        textBubble.GetComponent<TextMeshPro>().text = "Easy now...";
    }
    public override void onInteract()
    {
        textBubble.GetComponent<TextMeshPro>().text = "...";
    }
}
