using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;


    private void Update()
    {
        CheckGround();
    }

    // 땅을 감지하는 레이캐스트
    private void CheckGround()
    {
        // 레이캐스트 발사 방향을 아래로 설정
        Vector3 rayDirection = Vector3.down;

        // 레이캐스트 시각화 (씬 뷰에서 보임)
        Debug.DrawRay(transform.position, rayDirection * 1.55f, Color.red);

        // 캐릭터 아래 방향으로 레이캐스트 발사
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 1.55f))
        {
            // 레이캐스트가 태그가 맞는 오브젝트에 닿았는지 확인
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleCol") || hit.collider.CompareTag("ObstacleTri"))
            {
                _jumperData._isGrounded = true;
            }
            else
            {
                _jumperData._isGrounded = false;
            }
        }
        else
        {
            _jumperData._isGrounded = false;
        }
    }

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
}
