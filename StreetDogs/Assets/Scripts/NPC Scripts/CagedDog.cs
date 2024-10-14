using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CagedDog : Interactable
{
    public DogWardenNPC warden;
    public GameObject cage;
    public bool hasKey = false;

    public Image fade;
    private bool shouldFade;
    private float fadeAlpha;
    //[SerializeField] SceneAsset creditsScene;
    //private string creditsSceneName;
    
    private void Awake()
    {
        //Uses behavior from parent class, with additional code
        base.Awake();
    }

    private void Start()
    {
        //if (creditsScene != null)
        //{
            //creditsSceneName = creditsScene.name;
        //}
        //else
        //{
            //Debug.LogWarning("Credits Scene is not set!");
        //}
    }

    //Makes character run away and disappear for Growl interaction
    private void Update()
    {
        base.Update();
        if (shouldFade)
        {
            if (fadeAlpha < 1)
            {
                fadeAlpha += .005f;
                fade.color = new Color(0, 0, 0, fadeAlpha);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }

    public override void onBark()
    {
        completeTask();
        //START BARKING
        warden.shouldMoveLeft = true;
        warden.shouldDropKey = true;
    }
    public override void onBeg()
    {
        //No behavior
        completeTask();
    }
    public override void onGrowl()
    {
        completeTask();
        //START BARKING
        warden.shouldMoveLeft = true;
        warden.shouldDropKey = true;
    }
    public override void onInteract()
    {
        if (hasKey)
        {
            player.tasksCompleted++;
            taskIcon.sprite = null;
            taskIcon.color = new Color(1, 1, 1, 0);
            hasDoneAction = true;
            canBeInteracted = false;
            StartCoroutine(FadeDelay());
            Destroy(cage);
        }
        else
        {
            completeTask();
        }
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(3);
        shouldFade = true;
    }
}
