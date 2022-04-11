using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameManager gameManager;
    private StoryManager storyManager;
    private DialogueManager dialogueManager;
    public Animator animator;
    public GameObject OpenJournal;
    public GameObject ClosedJournal;
    public GameObject endDayButton;

    void Awake() {
        gameManager = GetComponent<GameManager>();
        storyManager = GetComponent<StoryManager>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    void Start() {
        endDayButton.SetActive(false);
        closeJournal();
    }

    public void closeJournal() {
        OpenJournal.SetActive(false);
        ClosedJournal.SetActive(true);
    }

    public void openJournal() {
        OpenJournal.SetActive(true);
        ClosedJournal.SetActive(false);
    }


    public void SetEndDayAndUpdateAll() {
        animator.SetTrigger("EndDay");
        StartCoroutine(UpdateAllCoroutine());
    }

    IEnumerator UpdateAllCoroutine (){
        
        yield return new WaitForSeconds(2);
        
        OpenJournal.SetActive(false);
        ClosedJournal.SetActive(true);
        storyManager.UpdateRoom();
        endDayButton.SetActive(false);

    }

}
        