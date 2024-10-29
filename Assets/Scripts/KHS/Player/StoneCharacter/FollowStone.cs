using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowStone : MonoBehaviour
{
    [SerializeField] Transform _child;
    [SerializeField] Transform _parent;
    [SerializeField] LayerMask _layerMask;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Vector3 childPos = new Vector3(_child.position.x, _child.position.y, 0);
            Debug.Log($"자식 위치 : {childPos}");

            //if (Physics.Raycast(childPos, Vector3.down, out RaycastHit hitInfo, 5f, _layerMask))
            //{
            //    _parent.position = hitInfo.point + Vector3.up * 0.1f;
            //}

            _parent.position = childPos;
            Debug.Log($"부모 위치 : {_parent.position}");

            _child.localPosition = Vector3.zero;
        }
    }
}
