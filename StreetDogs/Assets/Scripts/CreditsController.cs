using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private Animator creditsAnimator; 
    [SerializeField] private string animationName;
    [SerializeField] private float creditsDuration = 900f;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    void Start()
    {
        if (creditsAnimator != null && !string.IsNullOrEmpty(animationName))
        {
            creditsAnimator.Play(animationName);
        }
        else
        {
            Debug.LogWarning("Animator or animation name not set");
        }

        Invoke("ReturntoMainMenu", creditsDuration);
    }

    private void ReturntoMainMenu()
    {
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            Debug.LogWarning("Main menu scene not set");
        }
    }
}
