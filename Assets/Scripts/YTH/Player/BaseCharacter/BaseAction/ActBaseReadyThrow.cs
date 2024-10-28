using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
