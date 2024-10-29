using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Progress;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
           //if (Input.GetKeyUp(KeyCode.Mouse0) == false) // 좌클릭 떼고, 좌클릭 누른 상태가 아닐 때
           //{
                ThrowItem();
           // }
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

        if (Physics.Raycast(ray, out hit, 10f)) // 10f 거리는 테스트용 수정 필요
        {
            // 아이템 마우스 방향으로 던짐
            Vector3 throwDirection = (hit.point - transform.position).normalized;

            // 비활성화된 물리 작용 활성화하여 던짐
            Rigidbody _itemRb = _item.GetComponent<Rigidbody>();
            _item.transform.SetParent(null);
            _itemRb.isKinematic = false;
            _itemRb.AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
        }
    }
}
