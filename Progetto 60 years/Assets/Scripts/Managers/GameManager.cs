using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    private StoryManager storyManager;

    public Character[] characters;
    public GameObject[] charactersGO;
    
    void Awake() {
        storyManager = GetComponent<StoryManager>();
    }
    void Start() {
        UpdateCurrentStoryNode();
        UpdateCharacterPositions();
    }

    void UpdateCurrentStoryNode() {
        storyManager.clear();
        storyManager.UpdateChoices();

        DisplayCurrentNodeDescription(storyManager.currentStoryNode.description.textString);


    }

    public void UpdateAll(){
        UpdateCharacterPositions();
        UpdateCurrentStoryNode();
    }

    public void UpdateCharacterPositions() {

        int i = 0;

        foreach (Character character in characters) {

            if (character.hasBeenFound == true && character.isAway == false) {
                charactersGO[i].SetActive(true);
            }
            else {
               charactersGO[i].SetActive(false);
            }

            i++;

        }
    }

    public void SetCharacterAway(bool isAway) {
        characters[0].isAway = isAway;
    }

    public void DisplayCurrentNodeDescription(string text) {
        textLabel.text = text;
    }

    


}