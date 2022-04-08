using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused())
                pause();

            else if (optionsMenuUI.activeSelf) {
                optionsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }

            else
            {
                resume();
            }
                
        }

    }

    bool IsPaused() {
        if (Time.timeScale == 0f) return true;
        else return false;
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void quitToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

}
