using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionLabel;
    [SerializeField] private TMP_Text choiceLabel;
    [SerializeField] private TMP_Text[] buttonsLabels;
    [SerializeField] private GameObject[] buttonsGOs;
    
    private StoryManager storyManager;
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

        DisplayCurrentNodeDescription(storyManager.currentStoryNode.description);


    }

    public void UpdateAll(){
        UpdateCharacterPositions();
        UpdateCurrentStoryNode();
    }

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
    public void DisplayCurrentNodeDescription(NextChoiceDescription description) {

        //Aggiorna i Label di testo del diario
        descriptionLabel.text = description.descriptionString;
        choiceLabel.text = description.choiceString;

        int i = 0;

        //Per ogni scelta presente nel nodo corrente genera i bottoni e ci mette le stringhe sopra
        foreach (String choiceButtonText in description.choicesButtonTexts) {
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

}
