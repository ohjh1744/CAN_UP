using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//BTActino노드 담당
public class BTAction : BTNode
{
    private Func<BTNodeState> _action;
    // 의존성 주입 방식을 사용하여 상태 연결.
    public BTAction(Func<BTNodeState> action)
    {
        this._action = action;
    }

    public override BTNodeState Evaluate()
    {
        return _action();
    }
}
