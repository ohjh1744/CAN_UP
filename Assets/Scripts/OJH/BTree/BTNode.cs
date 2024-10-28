using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//BTNode 상태
public enum BTNodeState
{
    Success,
    Failure,
    Running
}
//BTNode 기본 구조
public abstract class BTNode 
{
    // 자식노드들 저장하는 공간
    protected List<BTNode> _children = new List<BTNode>();

    // 자식 추가하는 함수
    public void AddChild(BTNode node)
    {
        _children.Add(node);
    }

    // 노드 실행 함수
    public abstract BTNodeState Evaluate();
}
