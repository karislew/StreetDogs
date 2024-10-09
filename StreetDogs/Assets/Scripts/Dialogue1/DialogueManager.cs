using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    //public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject window;

    private Queue<string> sentences;
    // Start is called before the first frame update

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    void Start()
    {
        sentences = new Queue<string>();
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //nameText.text = name;
        sentences.Clear();
        ToggleWindow(true);
     
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }



        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        else
        {
            DisplayNextSentence();
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue()
    {
        Debug.Log("End of Convo");
        ToggleWindow(false);
    }

    // Update is called once per frame
    
}
