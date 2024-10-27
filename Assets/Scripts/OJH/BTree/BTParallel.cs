using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 모든 노드를 병렬로 실행. 하나라도 Running 상태가 있으면 Running return, 아닌 경우 모든 노드가 성공하면 success 리턴. 아니라면 Failure 리턴.
public class BTParallel : BTNode
{
    public override BTNodeState Evaluate()
    {
        bool isAnyRunning = false;
        bool isAllSuccess = true;

        foreach (BTNode node in _children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Running)
            {
                isAnyRunning = true;
            }
            else if (result == BTNodeState.Failure)
            {
                isAllSuccess = false;
            }
        }

        return isAnyRunning ? BTNodeState.Running : (isAllSuccess ? BTNodeState.Success : BTNodeState.Failure);
    }
}
