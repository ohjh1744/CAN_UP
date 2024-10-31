using System.Collections;
using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    [SerializeField] Animator _animator;

    [SerializeField] Transform throwPoint;
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            throwRoutine = StartCoroutine(ThrowRoutine());
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    public void ThrowItem()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(throwPoint.position).z;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = throwPoint.position.z; // Z축 고정

        // 던질 방향 계산 (X, Y축만 고려)
        Vector3 throwDirection = (worldMousePos - transform.position).normalized;
        throwDirection.z = 0; // Z축을 0으로 고정

        Rigidbody _itemRb = _item.GetComponent<Rigidbody>();                                  // 물리 기능 활성화하여 던지는 기능
        Collider _collider = _item.GetComponent<Collider>();                                  //
        _item.transform.SetParent(null);                                                      //
        _itemRb.isKinematic = false;                                                          //
        _collider.enabled = true;                                                             //
        _collider.isTrigger = true;                                                           // 
        _itemRb.AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);               //

        _data.HasItem = false;
    }

    Coroutine throwRoutine;
    IEnumerator ThrowRoutine()
    {
        WaitForSeconds dealy = new(0.5f);

        _animator.SetTrigger("Throw");
        yield return dealy;
        ThrowItem();
        throwRoutine = null;
    }
}
