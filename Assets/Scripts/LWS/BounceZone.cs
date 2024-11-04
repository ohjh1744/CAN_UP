using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BounceZone : MonoBehaviour
{
    [SerializeField] PhysicMaterial _physic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            other.material = _physic;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            other.material = null;
        }
    }
}
