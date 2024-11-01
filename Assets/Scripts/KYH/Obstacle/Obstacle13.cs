using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle13 : MonoBehaviour, IResetObject, IObjectPosition
{
    // Reset 시 시작 각도 저장용 변수
    private Quaternion _startRot;

    // Reset 시 사용할 스테이지 목차
    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    // 발판 회전 각도
    [SerializeField] private float _rotateAngle;

    // 발판이 회전했는지 체크
    [SerializeField] private bool _isRotate;

    // 회전축 오브젝트
    [SerializeField] private GameObject _rotatePos;

    // 발판의 Rigidbody 참조용
    [SerializeField] private Rigidbody _rigid;

    private Coroutine _rotateRoutine;

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
        // 처음의 회전 각도를 저장
        _startRot = transform.rotation;
    }

    // 발판 회전 함수(플레이어용)
    public void RotatePlatform(PlayerController player)
    {
        // 이미 회전했으면 예외 처리
        if (_isRotate == true)
            return;

        // _rotatePos를 회전축으로 _rotateAngle의 정도만큼 회전
        gameObject.transform.RotateAround(_rotatePos.transform.position, Vector3.forward, _rotateAngle);
        _isRotate = true;   // 회전했다고 체크

    }

    // 발판 회전 함수(아이템용)
    public void RotatePlatform(Item item)
    {
        // 이미 회전했으면 예외 처리
        if (_isRotate == true)
            return;

        // _rotatePos를 회전축으로 _rotateAngle의 정도만큼 회전
        gameObject.transform.RotateAround(_rotatePos.transform.position, Vector3.forward, _rotateAngle);
        _isRotate = true;   // 회전했다고 체크

    }

    public void Reset()
    {
        transform.rotation = _startRot;
    }
}
