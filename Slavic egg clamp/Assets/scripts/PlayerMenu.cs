using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUi;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (isPaused)
        {
            Cursor.lockState= CursorLockMode.None;
        }
        else
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeButton()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void QuitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }


}
