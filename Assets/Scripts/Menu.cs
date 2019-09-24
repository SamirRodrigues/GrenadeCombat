using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool PauseGame = true;
    public static bool ControlsInstructions = false;
    public GameObject MenuUI;
    public GameObject Instructions;

    private void Awake()
    {
        LoadControlsMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame == true && ControlsInstructions == false)
            {
                Pause();
            }
            else if (PauseGame == true && ControlsInstructions == true)
            {
                LoadControlsMenu();
            }
            else
            {
                if (PauseGame == false && ControlsInstructions == false)
                {
                    Resume();
                }
                else if (PauseGame == false && ControlsInstructions == true)
                {
                    BackButton();
                }                
            }
        }
        
    }

    public void Resume()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = true;
    }

    public void Pause()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = false;
    }

    public void LoadControlsMenu()
    {
        Time.timeScale = 0f;
        ControlsInstructions = true;
        MenuUI.SetActive(false);
        Instructions.SetActive(true);
    }

    public void BackButton()
    {
        ControlsInstructions = false;
        Instructions.SetActive(false);
        MenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
