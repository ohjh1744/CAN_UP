using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle13 : MonoBehaviour, IResetObject
{
    private Quaternion _startRot;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    [SerializeField] private float _rotateSpeed;

    [SerializeField] private float _rotateAngle;

    [SerializeField] private bool _isRotate;

    [SerializeField] private GameObject _rotatePos;

    [SerializeField] private Rigidbody _rigid;

    private Coroutine _rotateRoutine;

    private void Start()
    {
        _startRot = transform.rotation;
    }

    public void RotatePlatform(PlayerController player)
    {
        if (_isRotate == true)
            return;

        gameObject.transform.RotateAround(_rotatePos.transform.position, Vector3.forward, _rotateAngle);
        _isRotate = true;

    }

    public void Reset()
    {
        transform.rotation = _startRot;
    }
}
