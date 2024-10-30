using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle8 : MonoBehaviour
{    // 내려오는 속도
    [SerializeField] private float _fallSpeed;

    // 원래 위치로 돌아가는 속도
    [SerializeField] private float _returnSpeed;

    // 내려온 후 다시 올라가기까지의 대기 시간
    [SerializeField] private float _stayTime;

    // 이동할 거리
    [SerializeField] private float _fallDistance;

    // 발판의 시작 위치 저장
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _endPos;

    // 발판이 내려오고 있는지 여부
    [SerializeField] private bool _isFalling;
    [SerializeField] private bool _isReturning;
    [SerializeField] private float _stayTimer;

    private void Start()
    {
        // 시작 위치와 내려온 위치 설정
        _startPos = transform.position;
        _endPos = _startPos - new Vector3(0, _fallDistance, 0);
    }

    private void Update()
    {
        if (_isFalling)
        {
            // 내려오는 동안 위치를 fallPosition까지 이동
            transform.position = Vector3.MoveTowards(transform.position, _endPos, _fallSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 대기 시간 시작
            if (Vector3.Distance(transform.position, _endPos) < 0.01f)
            {
                _isFalling = false;
                _stayTimer = _stayTime;
            }
        }
        else if (_stayTimer > 0f)
        {
            // 대기 시간 경과
            _stayTimer -= Time.deltaTime;

            // 대기 시간이 끝나면 원래 위치로 돌아가기
            if (_stayTimer <= 0f)
            {
                _isReturning = true;
            }
        }
        else if (_isReturning)
        {
            // 원래 위치로 돌아가기
            transform.position = Vector3.MoveTowards(transform.position, _startPos, _returnSpeed * Time.deltaTime);

            // 시작 위치에 도달하면 이동 종료
            if (Vector3.Distance(transform.position, _startPos) < 0.01f)
            {
                _isReturning = false;
            }
        }
    }

    // 어댑터를 통해 호출될 메서드
    public void ActivateFall(PlayerController player)
    {
        if (!_isFalling && !_isReturning) // 이동 중이 아닐 때만 실행
        {
            _isFalling = true;
        }
    }
}
