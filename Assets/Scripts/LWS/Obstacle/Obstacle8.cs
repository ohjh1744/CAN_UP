using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle8 : MonoBehaviour
{    // 내려오는 속도
    [SerializeField] private float fallSpeed = 20f;

    // 원래 위치로 돌아가는 속도
    [SerializeField] private float returnSpeed = 5f;

    // 발판이 내려올 시작 위치와 끝 위치
    private Vector3 startPosition;
    [SerializeField] private float fallDistance = 2f; // 내려오는 거리

    // 플레이어 감지 범위
    [SerializeField] private float detectionRange = 1f;

    // 발판이 내려오고 있는지 여부
    private bool isFalling;

    private void Start()
    {
        // 발판의 초기 위치 저장
        startPosition = transform.position;
    }

    private void Update()
    {
        // 플레이어의 머리 위에 발판이 있는지 감지
        if (PlayerIsBelow() && !isFalling)
        {
            isFalling = true;
        }

        // 발판이 내려오거나 원래 위치로 돌아감
        if (isFalling)
        {
            Vector3 targetPosition = startPosition - new Vector3(0, fallDistance, 0);
            MovePlatform(targetPosition, fallSpeed);
        }
        else
        {
            MovePlatform(startPosition, returnSpeed);
        }
    }

    private bool PlayerIsBelow()
    {
        // 플레이어가 일정 거리 내에 있는지 확인
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
            float heightDifference = transform.position.y - player.transform.position.y;

            // 플레이어가 발판 아래에 있고, x축으로 일정 거리 내에 있는지 확인
            return distanceToPlayer < detectionRange && heightDifference > 0;
        }
        return false;
    }

    private void MovePlatform(Vector3 targetPosition, float speed)
    {
        // 발판이 목표 위치까지 이동하도록 설정
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 목표 위치에 도달하면 상태 전환
        if (transform.position == targetPosition)
        {
            isFalling = !isFalling;
        }
    }
}
