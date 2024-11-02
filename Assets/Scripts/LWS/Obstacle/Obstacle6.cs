using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour, IResetObject, IObjectPosition
{
    // 생성되고 날라올 벽
    [SerializeField] private GameObject _wall;

    // 벽이 이동하는 속도
    [SerializeField] private float _moveSpeed;

    // reset()에서 사용하기 위해 필요한 시작 트랜스폼 위치
    [SerializeField] private Vector3 _startPos;

    // 벽의 목표 위치
    [SerializeField] private Vector3 _targetPosition;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    // 이름 설정
    [SerializeField] string _name;

    private bool _isMoving;

    private void Awake()
    {
        _startPos = transform.position;
        _isMoving = false;
    }

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

    public void EnterWall(PlayerController player)
    {
        _isMoving = true; // 이동 시작 플래그 활성화
    }

    public void EnterWall(Item item)
    {
        _isMoving = true; // 이동 시작 플래그 활성화
    }

    private void Update()
    {
        // 벽이 목표 위치까지 이동하도록 업데이트
        if (_isMoving && _wall != null && Vector3.Distance(_wall.transform.position, _targetPosition) > 0.01f)
        {
            MoveWall();
        }
        else
        {
            _isMoving = false; // 목표 위치에 도달하면 이동 멈춤
        }
    }

    private void MoveWall()
    {
        _wall.transform.position = Vector3.MoveTowards(_wall.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _wall.transform.position = _startPos;
        _isMoving = false; // 리셋 시 이동 상태 초기화
    }
}
