using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//첫 노드부터 확인, 성공하거나 Running 중인 노드가 있다면 바로 리턴. 하나도 없다면 Failure 리턴.
public class BTSelector : BTNode
{
    public override BTNodeState Evaluate()
    {
        foreach (BTNode node in _children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Success)
            {
                return BTNodeState.Success;
            }
            else if (result == BTNodeState.Running)
            {
                return BTNodeState.Running;
            }
        }

        return BTNodeState.Failure;
    }
}
