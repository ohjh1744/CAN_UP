using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : MonoBehaviour, IObjectPosition
{
    // 발사 할 프리팹
    [SerializeField] GameObject _obstaclePrefab;

    // 프리팹을 던질 주기
    [SerializeField] private float _launchInterval;

    // 발사 방향
    // 1,0,0 = 오른쪽, -1,0,0 = 왼쪽
    [SerializeField] private Vector3 _direction;

    // 발사 속도
    [SerializeField] private float _launchSpeed;

    // 이름 설정
    [SerializeField] string _name;


    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void Start()
    {
        // launchInterval마다 발사
        InvokeRepeating(nameof(LaunchObstacle), 0f, _launchInterval);
    }

    private void LaunchObstacle()
    {
        // 프리팹 생성
        GameObject obstacle = Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);

        // 발사설정
        Rigidbody rigid = obstacle.GetComponent<Rigidbody>();

        rigid.velocity = _direction.normalized * _launchSpeed;
    }
}
