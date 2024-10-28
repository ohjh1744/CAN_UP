using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseReadyJump : PlayerAction
{
    [SerializeField] BaseData _baseData;

    [SerializeField] Rigidbody _rigidbody;
    public override BTNodeState DoAction()
    {

        if ((Input.GetKeyUp(KeyCode.Space) || _baseData.CanJumpTime > _baseData.MaxTime) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Debug.Log("점프!");
            _baseData.CanJumpTime = 0;
            _rigidbody.AddForce(Vector3.up * _baseData.JumpPower, ForceMode.Impulse);
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _baseData.CanJumpTime += Time.deltaTime;
            _baseData.JumpPower++;
            Debug.Log("점프력 차징 중");
            _rigidbody.AddForce(Vector3.up * _baseData.JumpPower, ForceMode.Impulse);
            return BTNodeState.Running;
        }

        return BTNodeState.Failure;
    }

}