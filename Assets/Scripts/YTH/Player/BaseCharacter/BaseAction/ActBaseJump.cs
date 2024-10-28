using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            Debug.Log("มกวม!");
           
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}
