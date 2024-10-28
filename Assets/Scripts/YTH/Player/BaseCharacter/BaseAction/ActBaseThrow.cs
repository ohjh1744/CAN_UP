using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) == null) // ÁÂÅ¬¸¯ ¶¼°í, ÁÂÅ¬¸¯ ´©¸¥ »óÅÂ°¡ ¾Æ´Ò ¶§
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
