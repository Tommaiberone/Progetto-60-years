using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    public StoryNode currentStoryNode;
    public Dictionary<string, StoryNode> choicesDictionary = new Dictionary<string, StoryNode>(); 

    private GameManager gameManager;
    private HUDManager hudManager;
    private DialogueManager dialogueManager;

    string choiceKeyString;

    void Awake() {
        gameManager = GetComponent<GameManager>();
        hudManager = GetComponent<HUDManager>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    public void UpdateChoices() {
        foreach (Choice choice in currentStoryNode.possibleChoices) {
            choicesDictionary.Add(choice.keyString, choice.nodeThisDecisionLeadsTo);
        }
    }

    public void TakeDecision(string choiceKeyString) {
        this.choiceKeyString = choiceKeyString;
        hudManager.endDayButton.SetActive(true);
    }

    public void UpdateRoom() {
        currentStoryNode = choicesDictionary[choiceKeyString];
        gameManager.UpdateAll();
        dialogueManager.currentStoryNode=currentStoryNode;
    }

    public void clear() {
        choicesDictionary.Clear();
    }

}