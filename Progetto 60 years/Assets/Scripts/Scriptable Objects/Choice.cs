using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice
{
    public string keyString;
    public bool isSemiChoice;
    public string transitionDescription;
    public StoryNode nodeThisDecisionLeadsTo;
}
