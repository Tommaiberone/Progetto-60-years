using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool JournalIsActive = true;
    public static bool HUDIsActive;

    public GameObject JournalUI;
    public GameObject HUD;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
                pause();

            else if (GameIsPaused && !JournalIsActive)
                resume();

            else if (GameIsPaused && JournalIsActive)
            {
                JournalUI.SetActive(true);
                setJournalActive();
            }
                
        }*/

    }

    public void setJournalActive()
    {
        JournalIsActive = true;
        JournalUI.SetActive(true);
    }

    public void setJournalInactive()
    {
        JournalIsActive = false;
        JournalUI.SetActive(false);
    }

    public void setHUDActive () {
        HUDIsActive = true;
        HUD.SetActive(true);
    }

    public void setHUDInactive () {
        HUDIsActive = false;
        HUD.SetActive(false);
    }


    public void closeJournal() {
        setJournalInactive();
        setHUDActive();
    }

    public void openJournal() {
        setJournalActive();
        setHUDInactive();
    }

    public void nextDay() {
        setJournalActive();
        setHUDInactive();
    }

}