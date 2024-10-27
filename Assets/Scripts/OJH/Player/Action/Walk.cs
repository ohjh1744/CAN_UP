using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("¿Ãµø¡ﬂ");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
