using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private TMP_Text descriptionLabel;
    [SerializeField] private TMP_Text choiceLabel;
    [SerializeField] private TMP_Text[] buttonsLabels;
    [SerializeField] private GameObject[] buttonsGOs;
    public GameObject[] charactersGO;
    private StoryManager storyManager;
    private DialogueManager dialogueManager;
    public Animator animator;
    public GameObject OpenJournal;
    public GameObject ClosedJournal;
    public GameObject endDayButton;
    public GameObject EndDayWithoutAnimationButton;

    //Acquisisce le componenti degli altri Manager
    void Awake() {
        storyManager = GetComponent<StoryManager>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    //Si accerta che all'avvio alcune componenti siano disattivate
    void Start() {
        endDayButton.SetActive(false);
        EndDayWithoutAnimationButton.SetActive(false);
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

    //Aggiorna il diario con i dettagli del giorno corrente
    public void DisplayCurrentNodeDescription(NextChoiceDescription description) {

        //Aggiorna i Label di testo del diario
        descriptionLabel.text = description.descriptionString;
        choiceLabel.text = description.choiceString;

        int i = 0;

        //Per ogni scelta presente nel nodo corrente genera i bottoni e ci mette le stringhe sopra
        foreach (string choiceButtonText in description.choicesButtonTexts) {
            buttonsGOs[i].SetActive(true);
            buttonsLabels[i].text = choiceButtonText;
            i++;
        }

        //Rende invisibili i bottoni in eccesso
        while (i<4) {
            buttonsGOs[i].SetActive(false);
            i++;
        }
         
    }

    //Aggiorna i personaggi nella scena
    public void UpdateCharacterPositions() {

        int i = 0;

        foreach (Character character in storyManager.currentStoryNode.characters) {

            if (character.hasBeenFound == true && character.isAway == false) {
                charactersGO[i].SetActive(true);
            }
            else {
                charactersGO[i].SetActive(false);
            }

            i++;

        }
    }

    //Funzione richiamata internamente dal bottone "EndDay" di Unity
    public void SetEndDayAndUpdateAll() {

        //Fa partire l'animazione del cambio giorno 
        animator.SetTrigger("EndDay");

        //Dà il via alla procedura di aggiornamento di ciò che c'è a schermo
        StartCoroutine(UpdateAllCoroutine());
    }

    //Funzione richiamata internamente dal bottone "EndDayWithoutAnimation" di Unity
    public void EndDayWithoutAnimation() {

        //Fa partire la procedura di Update dello storyManager
        storyManager.UpdateRoom();

        //Si accerta che siano disattivati i pulsanti di EndDay
        endDayButton.SetActive(false);
        EndDayWithoutAnimationButton.SetActive(false);
    }

    //Coroutine chiamata per aggiornare alla pressione del tasto EndDay
    IEnumerator UpdateAllCoroutine (){
        
        //Aspetta che lo schermo diventi nero prima di far partire i cambiamenti
        yield return new WaitForSeconds(2);
        
        //Fa partire la procedura di Update dello storyManager
        storyManager.UpdateRoom();

        //Si accerta che siano disattivati i pulsanti di EndDay
        endDayButton.SetActive(false);
        EndDayWithoutAnimationButton.SetActive(false);

    }

}
        