using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle11 : MonoBehaviour
{
    // X축과 Y축 중심기준 이동할 범위
    [SerializeField] private float _moveOffsetX;
    [SerializeField] private float _moveOffsetY;

    // 이동속도
    [SerializeField] private float _moveSpeed;

    // 이동주기
    [SerializeField] private float _moveInterval;

    // 기본 위치
    [SerializeField] private Vector3 _startPos;

    // 이동 방향 제어 변수
    [SerializeField] private bool _movingPositive;

    private void Start()
    {
        _startPos = transform.position;
        _movingPositive = true;

        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            // 목표 위치 지정 (offset적용)
            Vector3 targetPosition = _movingPositive
                ? _startPos + new Vector3(_moveOffsetX, _moveOffsetY, 0)
                : _startPos - new Vector3(_moveOffsetX, _moveOffsetY, 0);

            // 지정 후 이동
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed*Time.deltaTime);
                yield return null;
            }

            // 반대 방향 이동
            _movingPositive = !_movingPositive;

            // 주기만큼 대기
            yield return new WaitForSeconds(_moveInterval);
        }
    }
}
