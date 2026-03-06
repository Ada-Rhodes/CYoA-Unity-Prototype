using System;
using UnityEngine;
using System.Collections.Generic;

public class RuntimeDialogueGraph : ScriptableObject
{
    public string EntryNodeID;
    public List<RuntimeDialogueNode> AllNodes = new List<RuntimeDialogueNode>();
}

[Serializable]
public class RuntimeDialogueNode
{
    public string NodeID;
    public string SpeakerName;
    public string DialogueText;
    public List<ChoiceData> Choices = new List<ChoiceData>();
    public string NextNodeID;
    public string BackgroundImage;
    public Sprite ActorSprite;
    public int LocationIndex;
}

[Serializable]
public class ChoiceData
{
    public string ChoiceText;
    public string DestinationNodeID; 
}