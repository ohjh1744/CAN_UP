using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BounceZone : MonoBehaviour
{
    [SerializeField] PhysicMaterial _physic;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Base") || other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Jumper"))
        {
            other.collider.material = _physic;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Base") || other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Jumper"))
        {
            other.collider.material = null;
        }
    }
}
