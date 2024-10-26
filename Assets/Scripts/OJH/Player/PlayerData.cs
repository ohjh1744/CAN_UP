using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// PlayerData는 추후에 프로퍼티 수정 예정.
public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _jumpNum;    //mvp패턴 변수

    public int JumpNum { get {return _jumpNum; } set { _jumpNum = value; } }
    
    [SerializeField] private int _fallNum;  //mvp패턴 변수

    public int FallNum { get { return _fallNum; } set { _fallNum = value; } }

    [SerializeField] private float _jumpPower;

    public float JumpPower {  get { return _jumpPower; } set { _jumpPower = value; } }

    [SerializeField] private float _moveSpeed;

    public float MoveSpeed {  get { return _moveSpeed; }  set { _moveSpeed = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //추후에 SaveData 쪽과 연동할 예정.

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }


}
