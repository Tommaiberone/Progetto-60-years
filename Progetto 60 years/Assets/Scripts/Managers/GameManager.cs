using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public Character[] characters;
    public GameObject[] charactersGO;
    
    void Awake() {

         //Se è già presente un'istanza del GameManager lancia un'eccezione
         if (Instance) throw new Exception("GameManager already present in scene!");

         //Assegna all'istanza del gameManager questa classe
         Instance = this;

        characterPositions();
    }
    public void characterPositions() {

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

    public void setCharacterAway(bool isAway) {
        characters[0].isAway = isAway;
    }


}
