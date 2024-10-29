using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle12 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] Rigidbody _rigid;

    // OnCollisionEnter하면 발판이 천천히 내려가기
    public void PlatformDown(PlayerController player)
    {
        Debug.Log("dadf");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _endPos.position, _moveSpeed);
    }

    // OnCollisionExit하면 발판이 천천히 올라가기
    public void PlatformReturn(PlayerController player)
    {
        Debug.Log("dffff");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _startPos.position, _moveSpeed);
    }
}
