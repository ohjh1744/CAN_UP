using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JumperData : PlayerData
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    [SerializeField] private Vector3 _moveDir;

    public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    [SerializeField] private float _resist;

    public float Resist { get { return _resist; } set { _resist = value; } }

}
