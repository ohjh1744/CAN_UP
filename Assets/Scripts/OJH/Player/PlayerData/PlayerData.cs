using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// PlayerData는 추후에 프로퍼티 수정 예정.
[System.Serializable]
public class PlayerData : MonoBehaviour
{
    private int _jumpCount;

    public int JumpCount { get { return _jumpCount; } set { _jumpCount = value; OnJumpCount?.Invoke(); } }


    [SerializeField] private float _jumpPower;

    public float JumpPower { get { return _jumpPower; } set { _jumpPower = value; } }

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }


    // 경직 조건: 공중 상황, 장애물이 물리적으로 밀쳤을때
    //isStiff 변수의 경우는 장애물이 물리적으로 밀쳤을때에만 사용.             
    [SerializeField] private bool _isStiff;

    public bool IsStiff { get { return _isStiff; }  set { _isStiff = value; }  }


    //발판이 아래에 있는 경우 고려
    //기본적으로 평지에서의 체공시간보다 조금 더 길게 설정할 것
    [SerializeField] private float _checkedFallTime; //Base 캐릭터 체공시간
    public float CheckedTimeBase { get { return _checkedFallTime; } set { _checkedFallTime = value; } }

    public event UnityAction OnJumpCount;
    
}
