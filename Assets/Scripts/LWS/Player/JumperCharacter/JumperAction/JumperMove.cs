using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // 감속 비율
    private float _decelerationFactor = 0.9f;

    // JumperData, Rigidbody 가져오기
    private void Start()
    {
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();
    }

    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // Grounded 상태일 때는 이동 진행 X
        if (_jumperData._isGrounded)
        {
            return BTNodeState.Failure;
        }

        // A,D 입력시 이동 진행
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {            
            float horizontalInput = Input.GetAxis("Horizontal");

            // 현재 이동 방향이 반대인지 확인
            bool isOppositeDirection = (horizontalInput < 0 && _rigidbody.velocity.x > 0) || (horizontalInput > 0 && _rigidbody.velocity.x < 0);

            Debug.Log($"반대 방향 여부: {isOppositeDirection}");

            // 반대방향 키를 눌렀을 때 감속 적용
            if (isOppositeDirection)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x * (1 - _decelerationFactor), _rigidbody.velocity.y, _rigidbody.velocity.z);
                Debug.Log("감속 중");
            }
            else
            {
                _rigidbody.velocity = new Vector3(horizontalInput * _jumperData.MoveSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
                Debug.Log("공중에서 이동 중");
            }

            return BTNodeState.Running;
        }
        // 미 입력 시 Failure 반환
        else
        {
            return BTNodeState.Failure;
        }
    }
}
