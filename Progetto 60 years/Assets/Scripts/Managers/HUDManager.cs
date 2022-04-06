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
    private StoryManager storyManager;
    public Animator animator;
    public GameObject OpenJournal;
    public GameObject ClosedJournal;
    public GameObject endDayButton;

    void Awake() {
        gameManager = GetComponent<GameManager>();
        storyManager = GetComponent<StoryManager>();
    }

    void Start() {
        endDayButton.SetActive(false);
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


    public void SetEndDayAndUpdateAll() {
        animator.SetTrigger("EndDay");
        StartCoroutine(UpdateAllCoroutine());
    }

    IEnumerator UpdateAllCoroutine (){
        
        yield return new WaitForSeconds(2);
        
        setJournalActive();
        setHUDInactive();
        storyManager.UpdateRoom();
        endDayButton.SetActive(false);

    }

}
        