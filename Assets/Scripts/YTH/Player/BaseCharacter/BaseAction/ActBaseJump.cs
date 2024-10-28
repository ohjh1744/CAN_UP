using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _data.JumpPower += Time.deltaTime * 6f;
            Debug.Log("점프력 차징 중");
            return BTNodeState.Running;
        }
        else if ((Input.GetKeyUp(KeyCode.Space)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (_data.JumpPower >= _data.MaxJumpPower)
            {
                _data.JumpPower = _data.MaxJumpPower;
            }
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            Debug.Log("점프!");
            _data.JumpPower = 0;
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}
