using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActJumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] GameObject _rayShooter;

    [SerializeField] AudioSource _audio;

    [SerializeField] AudioClip _audioClip;

    private bool _isJumping;

    private bool _isSound;

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
        Debug.DrawRay(_rayShooter.transform.position, rayDirection * 1f, Color.red);
        Debug.Log("shootray");

        // 캐릭터 아래 방향으로 레이캐스트 발사
        RaycastHit hit;
        if (Physics.Raycast( _rayShooter.transform.position, rayDirection, out hit, 1f))
        {
            // 레이캐스트가 태그가 맞는 오브젝트에 닿았는지 확인
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleCol") || hit.collider.CompareTag("ObstacleTri"))
            {
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
             
            if(_isSound == false)
            {
                _isSound = true;
                _audio.PlayOneShot(_audioClip);
            }
            return BTNodeState.Running;

        }
        else
        {
            _isSound = false;
            return BTNodeState.Failure;
        }
    }
}
