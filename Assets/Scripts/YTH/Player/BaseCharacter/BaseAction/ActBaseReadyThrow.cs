using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // 좌클릭 누르는 중, 마우스를 떼지 않았을 때
        {
            Debug.Log("아이템 사용 가능 + 아이템 소지 확인 + 아이템 던질 준비 완료");
            return BTNodeState.Running;
        }
        else
        {
            Debug.Log("아이템 사용 가능 + 아이템 소지 확인 + 아이템 던질 준비 완XXXXX");
            return BTNodeState.Failure;
        }
    }
}

