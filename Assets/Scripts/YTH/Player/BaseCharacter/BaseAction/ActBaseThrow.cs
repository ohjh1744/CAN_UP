using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            ThrowItem();
            return BTNodeState.Success;
        }
        else
        {
            Debug.Log("아이템 사용 가능 + 아이템 소지 확인 + 아이템 던질 준비 완료");
            return BTNodeState.Failure;
        }

    }

    private void ThrowItem()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // 마우스 위치를 기준으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //방향 로직 수정
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.forward * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log("레이캐스트!");
        }

        // 아이템 마우스 방향으로 던짐
        Vector3 throwDirection = (hit.point - transform.position).normalized;

        // 비활성화된 물리 작용 활성화하여 던짐
        Rigidbody _itemRb = _item.GetComponent<Rigidbody>();
        Collider _collider = _item.GetComponent<Collider>();
        _item.transform.SetParent(null);
        _itemRb.isKinematic = false;
        _collider.enabled = true;
        _itemRb.AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
    }
}
