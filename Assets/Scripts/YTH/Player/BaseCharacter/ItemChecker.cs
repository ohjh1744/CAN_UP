using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Collider collider = other.GetComponent<Collider>();
            collider.isTrigger = false;
        }
    }
}
