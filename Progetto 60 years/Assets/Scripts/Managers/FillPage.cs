using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class FillPage : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextObject textObject;


    // Start is called before the first frame update
    void Start()
    {

		  textLabel.text = textObject.textString;
          

    }

}
