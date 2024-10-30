using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour, IResetObject
{
    // 생성될 벽의 프리팹
    [SerializeField] private GameObject _wallPrefab;

    // 벽이 이동하는 속도
    [SerializeField] private float _moveSpeed;

    // 벽이 생성될 위치와 목표 위치
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _targetPosition;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    //reset()에서 사용하기 위해 wallInstance를 저장할 필드
    private GameObject wallInstance;

    public void WallCreate(PlayerController player)
    {
        // 벽 생성 후 초기위치 저장
        wallInstance = Instantiate(_wallPrefab, _spawnPosition, Quaternion.identity);

        // 벽이 목표 위치까지 이동
        MoveWall();
    }

    // 벽 이동용 함수
    private void MoveWall()
    {
        wallInstance.transform.position = Vector3.MoveTowards(wallInstance.transform.position, _targetPosition, _moveSpeed*Time.deltaTime);
    }

    private void Update()
    {
        // UPDATE에서 닿을 때까지 이동
        if (wallInstance != null && Vector3.Distance(wallInstance.transform.position, _targetPosition) > 0.01f)
        {
            MoveWall();
        }
    }

    public void Reset()
    {
        if (wallInstance != null)
        {
            Destroy(wallInstance);
            wallInstance = null;
        }
    }
}
