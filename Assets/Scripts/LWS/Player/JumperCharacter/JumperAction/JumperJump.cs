using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    private bool _isJumping;

    private void Update()
    {
        CheckGround();

        if(_rigidbody.velocity.y > 0 && !_jumperData.IsGrounded)
        {
            if (!_isJumping)
            {
                _jumperData.JumpCount++;
            }
            _isJumping = true;
        }

    }

    

    // 땅을 감지하는 레이캐스트
    private void CheckGround()
    {
        // 레이캐스트 발사 방향을 아래로 설정
        Vector3 rayDirection = Vector3.down;

        // 레이캐스트 시각화 (씬 뷰에서 보임)
        Debug.DrawRay(transform.position, rayDirection * 1.75f, Color.red);

        // 캐릭터 아래 방향으로 레이캐스트 발사
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 1.75f))
        {
            // 레이캐스트가 태그가 맞는 오브젝트에 닿았는지 확인
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleCol") || hit.collider.CompareTag("ObstacleTri"))
            {
                Debug.Log("x");
                _jumperData.IsGrounded = true;
            }
        }
        else
        {
            _jumperData.IsGrounded = false;
        }
    }

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        if (_jumperData.IsGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _isJumping = false;

            return BTNodeState.Running;

        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}
