using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space 누르고 있는 상태
        {                                                                                         
            _data.JumpPower += Time.deltaTime * 6f;  // 점프력 상승중
            Debug.Log("점프력 차징 중");

            if (_data.JumpPower >= _data.MaxJumpPower)  // 점프력이 최대 점프력을 넘어서면 최대 점프력으로 점프                                                                                             
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
                _data.JumpPower = 0;
                return BTNodeState.Success;
            }
            return BTNodeState.Running;
        }

        if ((Input.GetKeyUp(KeyCode.Space)) &&  !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space 떼거나
        {                                                                                              // 점프력이 최대 점프력에 도달 시
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse); // 점프
            Debug.Log("점프!");

            _data.IsGrounded = false;
            _data.JumpPower = 0;
            return BTNodeState.Success;
        }

        else
        {
            return BTNodeState.Failure;
        }
    }
}
