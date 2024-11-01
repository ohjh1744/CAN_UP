using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // 좌클릭 누르는 중, 마우스를 떼지 않았을 때
        {
            _data.IsReadyToThrow = true;
            return BTNodeState.Running;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse1) && _data.IsReadyToThrow == true)
        {
            _data.IsReadyToThrow = false;
            return BTNodeState.Failure;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}

