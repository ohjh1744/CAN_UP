using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// PlayerData는 추후에 프로퍼티 수정 예정.
[System.Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _jumpNum;    //mvp패턴 변수

    public int JumpNum { get { return _jumpNum; } set { _jumpNum = value; } }

    [SerializeField] private int _fallNum;  //mvp패턴 변수

    public int FallNum { get { return _fallNum; } set { _fallNum = value; } }

    [SerializeField] private float _jumpPower;

    public float JumpPower { get { return _jumpPower; } set { _jumpPower = value; } }

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }


    // 경직 조건: 공중 상황, 장애물이 물리적으로 밀쳤을때
    //isStiff 변수의 경우는 장애물이 물리적으로 밀쳤을때에만 사용.             
    [SerializeField] private bool _isStiff;

    public bool IsStiff { get { return _isStiff; }  set { _isStiff = value; }  }



}
