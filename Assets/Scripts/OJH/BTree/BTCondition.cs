using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BTCondition : BTNode
{
    private Func<bool> _condition;

    public BTCondition(Func<bool> condition)
    {
        this._condition = condition;
    }

    public override BTNodeState Evaluate()
    {
        return _condition() ? BTNodeState.Success : BTNodeState.Failure;
    }
}
