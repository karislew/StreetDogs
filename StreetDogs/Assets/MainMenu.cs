using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsButton;
    public GameObject playerButton;

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void Options()
    {
        EventSystem.current.SetSelectedGameObject(optionsButton);
    }
    public void Back()
    {
        EventSystem.current.SetSelectedGameObject(playerButton);
    }
}
