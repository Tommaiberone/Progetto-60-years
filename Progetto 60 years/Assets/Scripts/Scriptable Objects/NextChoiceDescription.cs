using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NextChoiceDescription
{
    [TextArea] public string descriptionString;
    [TextArea] public string choiceString;
    public string[] choicesButtonTexts;
}
