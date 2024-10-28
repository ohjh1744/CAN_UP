using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseWalk : PlayerAction 
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = _data.MoveDir * _data.MoveSpeed;
            Debug.Log("¿Ãµø¡ﬂ");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
