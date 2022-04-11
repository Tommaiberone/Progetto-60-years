using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private GameManager gameManager;
    private StoryManager storyManager;
    private HUDManager hudManager;
    public StoryNode currentStoryNode;
    public GameObject DialogueBox;
    public Image characterImage;
    public TMP_Text dialogueSpeakerLabel;
    public TMP_Text dialogueTextLabel;

    void Awake() {
        gameManager = GetComponent<GameManager>();
        storyManager = GetComponent<StoryManager>();
        hudManager = GetComponent<HUDManager>();
    }

    // Start is called before the first frame update
    void Start()
    {        
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

    IEnumerator PlayText(TMP_Text label, string dialogue) {

        foreach (char c in dialogue) 
        {
            label.text += c;
            //playSound();
            yield return new WaitForSeconds (.2f);
        }


        yield return null;
    }

}
