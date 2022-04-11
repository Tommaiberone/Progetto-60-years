using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StoryNode : ScriptableObject
{
    public string currentStoryNode;
    public NextChoiceDescription description;

    public Choice[] possibleChoices;

    public Character[] characters;
    public MyObject[] objects;

}
