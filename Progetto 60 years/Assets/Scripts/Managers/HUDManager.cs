using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool JournalIsActive = true;
    public static bool HUDIsActive;

    private GameManager gameManager;
    public Animator animator;
    public GameObject OpenJournal;
    public GameObject ClosedJournal;

    void Awake() {
        gameManager = GetComponent<GameManager>();
    }

    public void setJournalActive()
    {
        JournalIsActive = true;
        OpenJournal.SetActive(true);
    }

    public void setJournalInactive()
    {
        JournalIsActive = false;
        OpenJournal.SetActive(false);
    }

    public void setHUDActive () {
        HUDIsActive = true;
        ClosedJournal.SetActive(true);
    }

    public void setHUDInactive () {
        HUDIsActive = false;
        ClosedJournal.SetActive(false);
    }


    public void closeJournal() {
        setJournalInactive();
        setHUDActive();
    }

    public void openJournal() {
        setJournalActive();
        setHUDInactive();
    }


    public void UpdateAll() {
        setJournalActive();
        setHUDInactive();
        animator.SetTrigger("EndDay");
        gameManager.UpdateAll();
    }

}
        