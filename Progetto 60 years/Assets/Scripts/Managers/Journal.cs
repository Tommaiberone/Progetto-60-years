using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool JournalIsActive = true;
    public static bool HUDIsActive;

    public Animator animator;
    public GameObject OpenJournal;
    public GameObject ClosedJournal;
    public GameObject nextPageButton;
    public GameObject prevPageButton;
    public GameObject[] Pages;
    private string currentPageName;
    private int numberOfPages;

    public BooleanChoice FirstChoice;
    public BooleanChoice SecondChoice;
    public BooleanChoice ThirdChoice;
    public BooleanChoice FourthChoice;

    private Dictionary<int, string> pageNumbers;
    private Dictionary<string, int> pageNames;


    void Start() {

        pageNumbers = new Dictionary<int, string>();
        pageNumbers.Add(1,    "FirstPage");
        pageNumbers.Add(2,    "SecondPage");
        pageNumbers.Add(3,    "ThirdPage");
        pageNumbers.Add(4,    "FourthPage");
        pageNumbers.Add(5,    "FifthPage");

        pageNames = new Dictionary<string, int>();
        pageNames.Add("FirstPage" ,   1);
        pageNames.Add("SecondPage",   2);
        pageNames.Add("ThirdPage" ,   3);
        pageNames.Add("FourthPage",   4);
        pageNames.Add("FifthPage" ,   5);

        
        currentPageName = pageNumbers[1];
        numberOfPages = Pages.Length;

        prevPageButton.SetActive(false);

        if (numberOfPages > 1) {
            nextPageButton.SetActive(true);
        } 

    }

    // Update is called once per frame
    void Update()
    {

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

    public void nextPage() {

        int currentPageNumber = pageNames[currentPageName];
        string nextPageName = pageNumbers[currentPageNumber+1];

        //Disattiva la pagina corrente e attiva quella successiva
        foreach (GameObject page in Pages) {

            if (page.name == currentPageName) {
                page.SetActive(false);
            }
            if (page.name == nextPageName) {
                page.SetActive(true);
            }
        }

        currentPageNumber++;
        currentPageName = pageNumbers[currentPageNumber];

        //Disattiva la possibilità di scorrere oltre il dovuto
        //e riattiva quella di tornare indietro quando possibile
        if (currentPageNumber > 1) {
            prevPageButton.SetActive(true);

            if (currentPageNumber == numberOfPages) {
                nextPageButton.SetActive(false);
            }
        }

        else if (currentPageNumber == 1 && numberOfPages>1) {
            nextPageButton.SetActive(true);
            prevPageButton.SetActive(false);
        }

    }

    public void prevPage() {

        int currentPageNumber = pageNames[currentPageName];
        string prevPageName = pageNumbers[currentPageNumber-1];

        //Disattiva la pagina corrente e attiva quella successiva
        foreach (GameObject page in Pages) {

            if (page.name == currentPageName) {
                page.SetActive(false);
            }
            if (page.name == prevPageName) {
                page.SetActive(true);
            }
        }

        currentPageNumber--;
        currentPageName = pageNumbers[currentPageNumber];

        //Disattiva la possibilità di scorrere oltre il dovuto
        //e riattiva quella di tornare indietro quando possibile
        if (currentPageNumber > 1) {
            if (currentPageNumber != numberOfPages) {
                nextPageButton.SetActive(true);
            }
        }

        else if (currentPageNumber == 1) {
            nextPageButton.SetActive(true);
            prevPageButton.SetActive(false);
        }

    }

    public void choice (BooleanChoice choice) {
        GameManager.Instance.setCharacterAway(choice.scelta);
    }


    public void nextDay() {
        setJournalActive();
        setHUDInactive();
        animator.SetTrigger("EndDay");
        GameManager.Instance.characterPositions();
    }

}