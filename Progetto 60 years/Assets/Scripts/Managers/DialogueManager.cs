using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private StoryManager storyManager;
    private HUDManager hudManager;
    public StoryNode currentStoryNode;
    public GameObject DialogueBox;
    public Image characterImage;
    public TMP_Text dialogueSpeakerLabel;
    public TMP_Text dialogueTextLabel;
    float timeBetweenLetters = .05f;

    void Awake() {
        storyManager = GetComponent<StoryManager>();
        hudManager = GetComponent<HUDManager>();
    }

    public IEnumerator PlayDialogue() {

        if (currentStoryNode.dialogue.dialogueList.Count == 0) {
            yield break;
        }

        DialogueBox.SetActive(true);

        int i=0;

        foreach(string dialogue in currentStoryNode.dialogue.dialogueList) {

            UpdateSprite(currentStoryNode.dialogue.speakerList[i]);
            StartCoroutine(ShowDialogueString(currentStoryNode.dialogue.speakerList[i], dialogue));

            yield return waitForNextDialogue(5f);

            this.dialogueSpeakerLabel.text = "";
            this.dialogueTextLabel.text = "";

            i++;

        }

        DialogueBox.SetActive(false);
    }

    void UpdateSprite(string speakerName) {

        if (speakerName == "Pippo") {
            characterImage.sprite = Resources.Load <Sprite>("S01E01Katya_01_Side_Neutral");
        }
        else {
            characterImage.sprite = Resources.Load <Sprite>("Lahkhadia_01_Side_Uniform_Angry");
        }
        //DialogueBox.GetComponent<Image>().sprite = Character1;
    }

    IEnumerator waitForNextDialogue( float timeout ) {

        while(!Input.GetKeyDown(KeyCode.Space)){
    
            yield return null;

            //Riduce il tempo rimasto al timer
            timeout -= Time.deltaTime;

            //Se è scaduto il tempo interrompe il ciclo
            if( timeout <= 0f ) break;
        }
    }

    IEnumerator ShowDialogueString(string dialogueSpeaker, string dialogueText) {

        this.dialogueSpeakerLabel.text = "";
        this.dialogueTextLabel.text = "";

        this.dialogueSpeakerLabel.text = dialogueSpeaker;
        StartCoroutine(PlayText(this.dialogueTextLabel, dialogueText));

        yield return null;

    }

    //Stampa lettera per lettera con un delay pari a "timeBetweenLetters"
    //la stringa dialogue sulla label fornitagli
    IEnumerator PlayText(TMP_Text label, string dialogue) {

        foreach (char c in dialogue) 
        {
            label.text += c;
            //playSound();
            yield return new WaitForSeconds (timeBetweenLetters);
        }

        yield return null;
    }

}
