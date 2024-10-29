using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRagdoll : MonoBehaviour
{
    [SerializeField] Rigidbody[] rigidbodies;
    [SerializeField] Animator animator;

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            //Debug.Log($"{rigidbody.name}");
            rigidbody.isKinematic = true;
        }
    }

    private void Update()
    {
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            if(rigidbody.velocity.z >= 0.1f || rigidbody.velocity.z <= -0.1f )
            {
                Vector3 rigidVelocity = rigidbody.velocity;
                rigidVelocity.z = 0;
                rigidbody.velocity = rigidVelocity;
            }
        }
    }

    [ContextMenu("RagDollOn")]
    public void RagDollOn()
    {
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        animator.enabled = false;
    }
    [ContextMenu("RagDollOff")]
    public void RagDollOff()
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true ;
        }

        animator.enabled = true;
    }

    public float SpeedRigdbody()
    {
        Vector3 velocity = Vector3.zero;

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            velocity += rigidbody.velocity;
        }

        Vector3 result = velocity / rigidbodies.Length;
        return result.magnitude;
    }

    public void AddForceRagdoll(Vector3 dir)
    {
        rigidbodies[0].AddForce(dir,ForceMode.Impulse);
    }
}
