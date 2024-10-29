using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 5f;
    private float power = 0.1f;
    [SerializeField] Rigidbody rb;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}
