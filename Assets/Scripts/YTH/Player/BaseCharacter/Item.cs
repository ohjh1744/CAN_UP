using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] Collider _collider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
        }
    }
}
