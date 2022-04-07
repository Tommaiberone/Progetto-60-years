using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool MenuIsActive = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
                pause();

            else if (GameIsPaused && !MenuIsActive)
                resume();

            else if (GameIsPaused && MenuIsActive)
            {
                OptionsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
                setMenuActive();
            }
                
        }

    }
    
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void quitToMainMenu()
    {
        GameIsPaused = false;
        MenuIsActive = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    public void setMenuActive()
    {
        if (MenuIsActive)
            MenuIsActive = false;
        else
            MenuIsActive = true;
    }
}
