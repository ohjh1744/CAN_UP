using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 첫 노드부터 확인, 실패하면 바로 failure return, 실패가 없을시 하나라도 Running이 있으면 Running 아니라면 Success 리턴.
public class BTSequence : BTNode
{
    public override BTNodeState Evaluate()
    {
        bool isAnyCHildRunning = false;
        foreach (BTNode node in children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Failure)
            {
                return BTNodeState.Failure;
            }
            else if (result == BTNodeState.Running)
            {
                isAnyCHildRunning = true;
            }
        }

        return isAnyCHildRunning ? BTNodeState.Running : BTNodeState.Success;
    }
}
