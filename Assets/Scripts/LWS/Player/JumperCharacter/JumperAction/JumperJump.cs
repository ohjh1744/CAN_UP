using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;
    
    // 땅에 닿아있는지 판단할 Grounded 불 변수
    private bool _isGrounded;

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // JumperData, Rigidbody 가져오기
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();

        // 땅에 닿을 때마다 점프 실행
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
        }
        return BTNodeState.Running;
    }

    // 땅에 닿아있는 프레임마다 _isGrounded = true -> 점프 실행
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
