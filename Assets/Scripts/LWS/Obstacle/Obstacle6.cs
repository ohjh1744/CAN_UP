using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour
{
    // 떨어질 벽의 프리팹
    [SerializeField] private GameObject wallPrefab;

    // 벽이 이동하는 속도
    [SerializeField] private float moveSpeed;

    // 대기 시간 설정
    private WaitForSeconds appearDelay;

    // 벽이 생성될 위치
    [SerializeField] private Vector3 spawnOffset;

    public void WallCreate(PlayerController player)
    {
        // 플레이어 위치 + offset에서 생성
        Vector3 spawnPosition = transform.position + spawnOffset;

        StartCoroutine(WallCreateRoutine(spawnPosition));
    }

    // 코루틴에서 벽 생성과 이동을 구현
    private IEnumerator WallCreateRoutine(Vector3 spawnPosition)
    {
        // 지정된 시간 후에 벽 생성
        yield return appearDelay;

        // 벽을 현재 위치에 생성하고 초기 위치 저장
        GameObject wallInstance = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);

        // 벽이 목표 위치까지 떨어지도록 이동
        while (Vector3.Distance(wallInstance.transform.position, transform.position) > 0.01f)
        {
            wallInstance.transform.position = Vector3.MoveTowards(wallInstance.transform.position, transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 오차를 허용해 도달하면 파괴
        if ( Vector3.Distance(wallInstance.transform.position,transform.position) < 0.01f)
        {
            Destroy(wallInstance);
        }
    }
}
