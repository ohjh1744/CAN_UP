using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BTAction : BTNode
{
    private Func<BTNodeState> _action;
    public BTAction(Func<BTNodeState> action)
    {
        this._action = action;
    }

    public override BTNodeState Evaluate()
    {
        return _action();
    }
}
