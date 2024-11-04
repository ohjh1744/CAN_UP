using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] Collider _collider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            Debug.Log("hi");
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
        }

        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColEnter(this);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColStay(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColExit(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriEnter(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriStay(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriExit(this);
        }
    }
}
