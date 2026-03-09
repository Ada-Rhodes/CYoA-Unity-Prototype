using UnityEngine;
using Unity.GraphToolkit.Editor;
using System;
using UnityEngine.TestTools.Constraints;
using Unity.Properties;
using System.ComponentModel;

[Serializable]
public class StartNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddOutputPort("out").Build();
    }
}

[Serializable]
public class EndNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("in").Build();
    }
}

[Serializable]
public class DialogueNode : Node
{
    public enum Location
        {
            Left = 0,
            Right = 1,
            LeftBottom = 2,
            RightBottom = 3
        }
    
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("in").Build();
        context.AddOutputPort("out").Build();

        context.AddInputPort<string>("Speaker").Build();
        context.AddInputPort<string>("Dialogue").Build();
        context.AddInputPort<int>("Active Speaker").Build();
        context.AddInputPort<Sprite>("Speaker Sprite 0").Build();
        context.AddInputPort<Sprite>("Speaker Sprite 1").Build();
        context.AddInputPort<Sprite>("Speaker Sprite 2").Build();
        context.AddInputPort<Sprite>("Speaker Sprite 3").Build();
        // context.AddInputPort<Location>("Frame").Build();
        
    }
}

[Serializable]
public class ChoiceNode : Node
{
    const string optionID = "nChoices";
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("In").Build();

        context.AddInputPort<string>("Speaker").Build();
        context.AddInputPort<string>("Dialogue").Build();

        var option = GetNodeOptionByName(optionID);
        option.TryGetValue(out int nChoices);
        for (int i = 0; i < nChoices; i++)
        {
            context.AddInputPort<string>($"Choice Text {i}").Build();
            context.AddOutputPort($"Choice {i}").Build();
        }
    }

    protected override void OnDefineOptions(IOptionDefinitionContext context)
    {
        context.AddOption<int>(optionID);
    }
}

[Serializable]
public class BackgroundNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("in").Build();
        context.AddOutputPort("out").Build();

        context.AddInputPort<Sprite>("Background Image").Build();
    }
}