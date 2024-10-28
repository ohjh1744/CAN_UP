using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondStoneCanMove : PlayerCondition
{
    [SerializeField] StoneData _data;

    public override bool DoCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.Log("레이케스트 시작");
        if (Physics.Raycast(ray, out RaycastHit hit, _data.RayDistance))
        {
            if(hit.collider.CompareTag("Ground"))
            {
                Debug.Log($"{hit.collider.tag}감지됨");
                return true;
            }
        }

        return false;
    }
}
