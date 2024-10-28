using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActStoneReadyMove : PlayerAction
{
    [SerializeField] StoneData _data;
    // 라인 렌더러
    [SerializeField] LineRenderer _lineRenderer;
    // 선택된 플레이어
    [SerializeField] GameObject selectedPlayer;

    public override BTNodeState DoAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 왼쪽 버튼 누름");
            return BTNodeState.Running;
        }
        else
        {
            Debug.Log("마우스 왼쪽 버튼 뗌");
            return BTNodeState.Failure;
        }
    }

    
}
