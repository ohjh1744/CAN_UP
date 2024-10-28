using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            Debug.Log("점프!");
            _data.JumpPower = 0;
            Debug.Log("점프력 0으로 리턴");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }


}
