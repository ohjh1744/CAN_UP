using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle13 : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotateAngle;
    [SerializeField] private Rigidbody _rigid;

    public void RotatePlatform(PlayerController player)
    {
        Debug.Log("fsda");
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime));
    }
}
