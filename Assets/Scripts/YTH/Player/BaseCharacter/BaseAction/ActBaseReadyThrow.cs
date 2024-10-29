using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // 좌클릭 누르는 중, 마우스를 떼지 않았을 때
        {
           // if (Input.GetKey(KeyCode.Mouse0) == true)
           // {
           //     return BTNodeState.Running;
           // }
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
