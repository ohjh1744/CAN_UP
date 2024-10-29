using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowStone : MonoBehaviour
{
    [SerializeField] Transform _child;
    [SerializeField] Transform _parent;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Vector3 childPos = _child.position;
            Debug.Log($"자식 위치 : {childPos}");
            _parent.position = childPos;
            Debug.Log($"부모 위치 : {_parent.position}");
            _child.localPosition = Vector3.zero;
        }
    }
}
