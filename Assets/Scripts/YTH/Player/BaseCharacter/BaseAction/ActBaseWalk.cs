using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseWalk : PlayerAction 
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if ((Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.Space)) //A 또는 D 키를 눌렀을 때, Space 입력하지 않았을 때 이동
        {
            _rigidbody.velocity = Vector3.left * _data.MoveSpeed;
            Debug.Log("left 이동중");
            return BTNodeState.Running;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = Vector3.right * _data.MoveSpeed;
            Debug.Log("right 이동중");
            return BTNodeState.Running;
        }

        else
        {
            return BTNodeState.Failure;
        }

    }
}
