using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle07 : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Transform _stopPos;
    [SerializeField] Rigidbody _rigid;

    public void TouchPlayer(PlayerController player)
    {
        Debug.Log("rrr");
        transform.position = Vector3.Lerp(gameObject.transform.position, _stopPos.position, 2.0f);
    }
}
