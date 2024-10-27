using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum BTNodeState
{
    Success,
    Failure,
    Running
}
public abstract class BTNode 
{
    protected List<BTNode> _children = new List<BTNode>();

    public void AddChild(BTNode node)
    {
        _children.Add(node);
    }

    public abstract BTNodeState Evaluate();
}
