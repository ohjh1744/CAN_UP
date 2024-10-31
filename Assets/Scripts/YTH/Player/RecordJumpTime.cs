using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecordJumpTime : MonoBehaviour
{
    [SerializeField] PlayerData _data;
    float _jumpTime;
    private void Awake()
    {
        _jumpTime = 0;
    }
 
    private void Update()
    {
        if (_data.IsGrounded == false)
        {
             _jumpTime += Time.deltaTime;
            Debug.Log(_jumpTime);
        }
        else if (_data.IsGrounded == true)
        {
            _jumpTime = _jumpTime;
            Debug.Log(_jumpTime);
        }

    }
}
