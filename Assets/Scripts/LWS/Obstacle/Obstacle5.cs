using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : MonoBehaviour
{
    // 반복 주기 (초)
    [SerializeField] float moveInterval;

    // 속도
    [SerializeField] float speed;

    // 이동 방향
    [SerializeField] Vector3 dir;

    // 초기 위치
    [SerializeField] Vector3 startPos;

    // 플레이어를 밀어낼 힘의 크기
    [SerializeField] float pushForce;

    [SerializeField] bool movingOut;

    private void Start()
    {
        startPos = transform.position;
        StartCoroutine(RoutineObstacle());
    }

    private IEnumerator RoutineObstacle()
    {
        while (true)
        {
            // 목표 위치 계산
            Vector3 targetPosition = movingOut ? startPos + dir : startPos;

            // 목표 위치까지 이동
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                yield return null;
            }

            movingOut = !movingOut;

            yield return new WaitForSeconds(moveInterval);
        }
    }

    public void PushPlayer(PlayerController player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            Vector3 pushDirection = (player.transform.position - transform.position).normalized;
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
