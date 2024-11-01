using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle07 : MonoBehaviour, IResetObject, IObjectPosition
{
    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    private Vector3 _startPos;

    [SerializeField] float _moveSpeed;

    [SerializeField] Transform _stopPos;

    [SerializeField] Rigidbody _rigid;

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
        _startPos = transform.position;
    }

    public void MovePlatform(PlayerController player)
    {
        // 멈추는 위치에 빈 오브젝트 설치할 것
        transform.position = Vector3.Lerp(gameObject.transform.position, _stopPos.position, 2.0f);
    }

    public void Reset()
    {
        transform.position = _startPos;
    }
}
