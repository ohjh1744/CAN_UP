using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActBasePickItem : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
