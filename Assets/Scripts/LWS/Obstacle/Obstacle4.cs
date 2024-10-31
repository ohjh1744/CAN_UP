using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4 : MonoBehaviour
{
    // 반복 주기 (초)
    [SerializeField] float _moveInterval;

    // 속도
    [SerializeField] float _speed;

    // 이동 방향
    [SerializeField] Vector3 _dir;

    // 초기 위치
    [SerializeField] Vector3 _startPos;

    // 플레이어를 밀어낼 힘의 크기
    [SerializeField] float _pushForce;

    [SerializeField] bool _movingOut;

    private void Start()
    {
        _startPos = transform.position;
        StartCoroutine(RoutineObstacle());
    }

    private IEnumerator RoutineObstacle()
    {
        while (true)
        {
            // 목표 위치 계산
            Vector3 targetPosition = _movingOut ? _startPos + _dir : _startPos;

            // 목표 위치까지 이동
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

                yield return null;
            }

            _movingOut = !_movingOut;

            yield return new WaitForSeconds(_moveInterval);
        }
    }

    public void PushPlayer(PlayerController player)
    {
        Rigidbody rigid = player.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            Vector3 pushDirection = (player.transform.position - transform.position).normalized;
            rigid.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
        }
    }

    public void PushItem(Item item)
    {
        Rigidbody rigid = item.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            Vector3 pushDirection = (item.transform.position - transform.position).normalized;
            rigid.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
        }
    }
}
