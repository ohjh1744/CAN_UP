using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseData : PlayerData
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    [SerializeField] private Vector3 _moveDir;

    public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //추후에 SaveData 쪽과 연동할 예정.

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }

}
