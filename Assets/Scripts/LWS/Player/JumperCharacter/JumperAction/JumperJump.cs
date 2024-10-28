using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // 땅에 닿아있는지 판단할 Grounded 불 변수
    private bool _isGrounded;

    // 점프 간격 시간 0.2초
    private float _jumpCooldown = 0.2f;

    // 게임 시작하자마자 점프 할 수 있도록, -1을 초기값으로 지정
    private float _groundedTime = -1f;

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // JumperData, Rigidbody 가져오기
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();

        // 현재 시간 = 땅에 닿아있는 시간 + 쿨타임보다 긴 지 확인
        if (_isGrounded && Time.time >= _groundedTime + _jumpCooldown)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _isGrounded = false; // 점프 직후에 땅에 닿지 않은 상태로 설정
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    // 땅에 닿아있는 프레임마다 _isGrounded = true -> 점프 실행
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _groundedTime = Time.time;
        }
    }
}
