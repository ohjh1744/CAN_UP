using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//BTCondition 노드담당
public class BTCondition : BTNode
{
    private Func<bool> _condition;

    //의존성 주입을 통한 상태 연결
    public BTCondition(Func<bool> condition)
    {
        this._condition = condition;
    }

    public override BTNodeState Evaluate()
    {
        return _condition() ? BTNodeState.Success : BTNodeState.Failure;
    }
}
