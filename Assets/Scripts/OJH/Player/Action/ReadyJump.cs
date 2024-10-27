using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyJump : PlayerAction
{
   
    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Debug.Log("점프력 차징 중");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
    
}
