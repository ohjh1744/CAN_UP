using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (Input.GetKeyUp(KeyCode.Mouse1) == null)
            {
                return BTNodeState.Success;
            }
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
