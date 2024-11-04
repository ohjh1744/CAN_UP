using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//첫 노드부터 확인, 성공하거나 Running 중인 노드가 있다면 바로 리턴. 하나도 없다면 Failure 리턴.
public class BTSelector : BTNode
{
    private BTNode _lastRunningNode;
    public override BTNodeState Evaluate()
    {
        if (_lastRunningNode != null)
        {
            if ((_lastRunningNode.Evaluate() == BTNodeState.Success))
            {
                return BTNodeState.Success;
            }
            else if ((_lastRunningNode.Evaluate() == BTNodeState.Running))
            {
                return BTNodeState.Running;
            }
        }

        foreach (BTNode node in _children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Success)
            {
                _lastRunningNode = node;
                return BTNodeState.Success;
            }
            else if (result == BTNodeState.Running)
            {
                _lastRunningNode = node;
                return BTNodeState.Running;
            }
        }

        return BTNodeState.Failure;
    }
}
