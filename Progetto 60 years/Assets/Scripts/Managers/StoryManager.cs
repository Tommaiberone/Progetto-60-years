using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    public StoryNode currentStoryNode;
    public Dictionary<string, StoryNode> choicesDictionary = new Dictionary<string, StoryNode>(); 

    public GameManager gameManager;

    void Awake() {
        gameManager = GetComponent<GameManager>();
    }

    public void UpdateChoices() {
        foreach (Choice choice in currentStoryNode.possibleChoices) {
            choicesDictionary.Add(choice.keyString, choice.nodeThisDecisionLeadsTo);
        }
    }

    public void UpdateRoom(string choiceKeyString) {
        currentStoryNode = choicesDictionary[choiceKeyString];
        gameManager.UpdateAll();
    }

    public void clear() {
        choicesDictionary.Clear();
    }

}