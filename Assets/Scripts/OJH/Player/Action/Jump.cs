using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("점프!");
            return BTNodeState.Running;
        }
        else
        {
            Debug.Log("점프력 0으로 리턴");
            return BTNodeState.Failure;
        }
    }
}
