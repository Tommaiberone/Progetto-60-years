using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    public StoryNode currentStoryNode;
    public Dictionary<string, StoryNode> choicesDictionary = new Dictionary<string, StoryNode>(); 

    private HUDManager hudManager;
    private DialogueManager dialogueManager;

    string choiceKeyString;

    //Acquisisce le componenti degli altri manager
    void Awake() {
        hudManager = GetComponent<HUDManager>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    void Start() {

        //Aggiorna le scelte presenti nel dizionario
        UpdateChoices();

        //Aggiorna il diario del giorno corrente
        hudManager.DisplayCurrentNodeDescription(currentStoryNode.description);
        hudManager.UpdateCharacterPositions();

        //Fa partire la coroutine del dialogo
        StartCoroutine(dialogueManager.PlayDialogue());
    }


    //Azzera il dizionario delle scelte e aggiunge tutte quelle presenti nel nodo corrente
    public void UpdateChoices() {

        choicesDictionary.Clear();

        foreach (Choice choice in currentStoryNode.possibleChoices) {
            choicesDictionary.Add(choice.keyString, choice.nodeThisDecisionLeadsTo);
        }
    }

    //Aggiorna la scelta presa e rende attivo il bottone giusto di EndDay
    //a seconda che quella corrente sia una scelta o una semiscelta
    public void TakeDecision(string choiceKeyString) {
        this.choiceKeyString = choiceKeyString;

        if (CheckIfSemiChoice()) {
            hudManager.EndDayWithoutAnimationButton.SetActive(true);
        }

        else {    
            hudManager.endDayButton.SetActive(true);
        }
    }

    //Controlla se la scelta corrente è una semiscelta
    public bool CheckIfSemiChoice () {
        foreach(Choice choice in currentStoryNode.possibleChoices) {
            if (choice.keyString == choiceKeyString) {
                if (choice.isSemiChoice) {
                    return true;
                }
            }
        }
        return false;
    }

    //Aggiorna complessivamente l'intera stanza
    public void UpdateRoom() {

        //Aggiorna il nodo corrente nei vari manager
        currentStoryNode = choicesDictionary[choiceKeyString];
        dialogueManager.currentStoryNode=currentStoryNode;
        
        //Aggiorna le scelte possibili da questo nodo
        UpdateChoices();

        //Aggiorna graficamente la stanza
        hudManager.DisplayCurrentNodeDescription(currentStoryNode.description);
        hudManager.UpdateCharacterPositions();

        //Fa partire il dialogo del nuovo giorno
        StartCoroutine(dialogueManager.PlayDialogue());
    }


}