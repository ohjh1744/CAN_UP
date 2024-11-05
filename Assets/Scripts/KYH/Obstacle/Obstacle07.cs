using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle07 : MonoBehaviour, IResetObject, IObjectPosition
{
    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    private Vector3 _startPos;

    [SerializeField] GameObject _gameObject;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private bool _isMove;

    [SerializeField] private Transform _stopPos;

    [SerializeField] private Rigidbody _rigid;

    // 이름 설정
    [SerializeField] private string _name;

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
        _startPos = _gameObject.transform.position;
    }

    public void MovePlatform(PlayerController player)
    {
        if (_isMove == true)
            return;

        // 멈추는 위치에 빈 오브젝트 설치할 것
        _gameObject.transform.position = Vector3.Lerp(_gameObject.transform.position, _stopPos.position, 2.0f);
        _isMove = true;
    }

    public void MovePlatform(Item item)
    {
        if (_isMove == true)
            return;

        // 멈추는 위치에 빈 오브젝트 설치할 것
        _gameObject.transform.position = Vector3.Lerp(_gameObject.transform.position, _stopPos.position, 2.0f);
        _isMove = true;
    }

    public void Reset()
    {
        _isMove = false;
        _gameObject.transform.position = _startPos;
    }
}
