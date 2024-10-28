using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // 점프 간격 시간 0.2초
    private float _jumpCooldown = 0.0f;

    // 게임 시작하자마자 점프 할 수 있도록, -1을 초기값으로 지정
    private float _groundedTime = -1f;

    // JumperData, Rigidbody 가져오기
    private void Start()
    {
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();
    }

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // 현재 시간 = 땅에 닿아있는 시간 + 쿨타임보다 긴 지 확인
        if (_jumperData._isGrounded && Time.time >= _groundedTime + _jumpCooldown)
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

    // 땅에 닿아있는 프레임마다 _isGrounded = true -> 점프 실행
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumperData._isGrounded = true;
            _groundedTime = Time.time;
        }
    }
}
