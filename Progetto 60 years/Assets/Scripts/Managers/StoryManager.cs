using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public StoryNode currentStoryNode;
    public Dictionary<string, StoryNode> choicesDictionary = new Dictionary<string, StoryNode>(); 

    private HUDManager hudManager;
    private DialogueManager dialogueManager;
    string choiceKeyString;
    public string transitionDescription;

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

    public void UpdateChoices() {
        
        //Azzera il dizionario delle scelte
        choicesDictionary.Clear();

        //Se il nodo corrente non presenta scelte da compiere rende immediatamente
        //attivo il pulsante prossimo giorno e imposta come stringa chiave del prossimo
        //nodo l'unico al quale si può giungere
        if (currentStoryNode.possibleChoices.Length == 1) {
            hudManager.endDayButton.SetActive(true);
            choiceKeyString = currentStoryNode.possibleChoices[0].keyString;
            transitionDescription = currentStoryNode.possibleChoices[0].transitionDescription;
        }

        //Altrimenti aggiunge al dizionario tutte quelle presenti nel nodo corrente
        else {
            foreach (Choice choice in currentStoryNode.possibleChoices) {
                choicesDictionary.Add(choice.keyString, choice.nodeThisDecisionLeadsTo);
            }
        }
    }

    //Aggiorna la scelta presa e rende attivo il bottone giusto di EndDay
    //a seconda che quella corrente sia una scelta o una semiscelta
    public void TakeDecision(string choiceKeyString) {

        this.choiceKeyString = choiceKeyString;

        //Cerca nelle scelte possibili quella corretta e imposta la transitionDescription
        //secondo quanto trovato nella scelta
        foreach (Choice choice in currentStoryNode.possibleChoices) {
            if (choice.keyString == choiceKeyString) {
                transitionDescription = choice.transitionDescription;
            }
        }

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