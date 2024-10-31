using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // Grounded 상태일 때는 이동 진행 X
        if (_jumperData.IsGrounded)
        {
            return BTNodeState.Failure;
        }

        // isStiff 일때는 반대 방향키 누를 시 튕겨져 나가는 속도 감속
        if (_jumperData.IsStiff)
        {
            bool horizontalInput = Input.GetButton("Horizontal");

            // 현재 속도 방향과 반대 방향인지 확인
            if ((horizontalInput == true && _rigidbody.velocity.x > 0 ))  
            {
                _rigidbody.AddForce(Vector3.left * _jumperData.Resist, ForceMode.Force);
            }
            
            else if ((horizontalInput == true && _rigidbody.velocity.x < 0))
            {
                _rigidbody.AddForce(Vector3.right * _jumperData.Resist, ForceMode.Force);
            }

            // 반대 키 입력이 없으면 제어 불가
            return BTNodeState.Failure;
        }

        // A,D 입력시 이동 진행
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {            
            float horizontalInput = Input.GetAxis("Horizontal");

            _rigidbody.velocity = new Vector3(horizontalInput * _jumperData.MoveSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);

            return BTNodeState.Running;
        }

        // 미 입력 시 Failure 반환
        else
        {
            return BTNodeState.Failure;
        }
    }
}
