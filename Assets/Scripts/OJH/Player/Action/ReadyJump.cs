using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyJump : PlayerAction
{
    [SerializeField] private float _maxTime;

    [SerializeField] private float _minTime;

    [SerializeField] private float _canJumpTime;
    
    public override BTNodeState DoAction()
    {

        if ((Input.GetKeyUp(KeyCode.Space) || _canJumpTime > _maxTime) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Debug.Log("점프!");
            _canJumpTime = 0;
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _canJumpTime += Time.deltaTime;
            Debug.Log("점프력 차징 중");

            return BTNodeState.Running;
        }
       

        return BTNodeState.Failure;
    }
    
}
