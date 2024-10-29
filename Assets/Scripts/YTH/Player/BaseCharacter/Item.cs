using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            //_rigidbody.isKinematic = true;
            Collider collider = gameObject.GetComponent<Collider>();
            collider.enabled = false;
        }

    }
}
