using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager
{

    public static void SaveGame () {    //Brackeys dà in input "Player player" perché deve salvare le
                                        //stats del player. Se devo salvare l'intera partita gli dovrò dare
                                        //in input una sorta di GameManager che contenga le variabili

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveGame.data";
        FileStream stream = new FileStream(path, FileMode.Create);

    }

}
