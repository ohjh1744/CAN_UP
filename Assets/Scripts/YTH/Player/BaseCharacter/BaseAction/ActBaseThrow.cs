using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Progress;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] Item _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) == null) // 좌클릭 떼고, 좌클릭 누른 상태가 아닐 때
            {
                ThrowItem();
            }
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }

    private void ThrowItem()
    {
        // 마우스 위치를 기준으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 아이템dmf 마우스 방향으로 위치로 던짐
            Vector3 throwDirection = (hit.point - transform.position).normalized;
            _item.GetComponent<Rigidbody>().AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
        }
    }
}
