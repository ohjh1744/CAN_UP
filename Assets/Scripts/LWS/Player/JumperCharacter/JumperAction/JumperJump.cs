using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // 현재 시간 = 땅에 닿아있는 시간 + 쿨타임보다 긴 지 확인
        if (_jumperData._isGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _jumperData._isGrounded = false; // 점프 직후에 땅에 닿지 않은 상태로 설정
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    // 땅에 닿으면 _isGrounded = true -> 점프 실행
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ObstacleCol") || collision.gameObject.CompareTag("ObstacleTri"))
        {
            _jumperData._isGrounded = true;
        }
    }
}
