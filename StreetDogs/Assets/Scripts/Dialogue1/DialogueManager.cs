using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    //public TMP_Text nameText;
    public GameObject[] dialogueBoxes;
    private TMP_Text activeDialogueText;
    private GameObject activeDialogueBox;
    public GameObject window;
    
    private Animator currentAnimator; 

    

    private Queue<string> sentences;
   
    
    // Start is called before the first frame update

   
    void Start()
    {
        sentences = new Queue<string>();
        
    }
    public void StartDialogue(Dialogue dialogue,GameObject dialogueBox,TMP_Text dialogueText)
    {
        activeDialogueText = dialogueText;
        activeDialogueBox = dialogueBox;
        //activeDialogueBox.SetActive(true);
        //currentAnimator=animator;
        //currentAnimator.SetBool("IsOpen", true);
        //nameText.text = name;
        sentences.Clear();
       
        
     
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Debug.Log("senences" + sentences.Count);



        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            Debug.Log("About to end");
            EndDialogue();
            return;
        }
        else{
            
            string sentence = sentences.Dequeue();
            activeDialogueText.text = sentence;
            StartCoroutine(Wait());
        }
    }
    void EndDialogue()
    {
        Debug.Log("End of Convo");
        //activeDialogueBox.SetActive(false);
        activeDialogueBox =null;
        activeDialogueText = null;

        //currentAnimator.SetBool("IsOpen", false);
        //ToggleWindow(false);
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        DisplayNextSentence();
    }

    // Update is called once per frame
    
}
