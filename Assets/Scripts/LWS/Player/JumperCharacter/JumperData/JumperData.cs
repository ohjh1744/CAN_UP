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

    // 땅에 닿아있는지 판단할 Grounded 불 변수
    public bool _isGrounded { get; set; }
}
