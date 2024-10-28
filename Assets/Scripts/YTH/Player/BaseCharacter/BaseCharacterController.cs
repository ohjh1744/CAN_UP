using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody[] _rigidbodies;

    [SerializeField] Animator _animator;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody _rigid in _rigidbodies)
        {
            _rigid.isKinematic = true;
        }
    }

    public void TakeDamage()
    {
        //렉돌 활성화하기 위해
        //1. 몸 부의의 파츠들이 중력을 받을 수 있도록 설정
        foreach (Rigidbody _rigid in _rigidbodies)
        {
            _rigid.isKinematic = false;
        }
        //2. 애니메이터를 설정
        _animator.enabled = false;

    }
}
