using UnityEngine;

[System.Serializable]
public class BaseData : PlayerData
{
    [SerializeField] private float _moveSpeed; // 이동 속도

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

   // private float _z;
   //
   // public float Z { get { return _z; } private set { } }

   // [SerializeField] private Vector3 _moveDir;
   //
   // public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    [SerializeField] private float _maxJumpPower; // 최대 점프력 = 5m

    public float MaxJumpPower { get { return _maxJumpPower; } set { _maxJumpPower = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //추후에 SaveData 쪽과 연동할 예정.

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }

    [SerializeField] private bool _isGrounded; // 땅에 닿아있는지 여부

    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }

    
}
