using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePaused=false;
    public GameObject pauseMenuUI;
    PlayerInput playerControls;
    private InputAction escape;
    
    [SerializeField] private InputActionAsset inputActions;
    private PlayerInput playerInput;
   
    private void Awake()
    {
        var uiActionMap= inputActions.FindActionMap("UI");
        escape =uiActionMap.FindAction("EscapeKey");
        //playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        //escape = playerControls.UI.EscapeKey;
        escape.Enable();

    }
    // Update is called once per frame
    void Update()
    {
        bool isESCPressed = escape.triggered;
        if(isESCPressed)
        {
            if(GamePaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //freeze game
        Time.timeScale = 1f;
        GamePaused = false;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //freeze game
        Time.timeScale = 0f;
        GamePaused= true;

    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
  
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
