using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    public override bool DoCheck()
    {
        Debug.Log("작동 1");
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _data.GroundCheckDistance))
        {
            if (hitInfo.collider.CompareTag("Ground"))
            {
                Debug.Log(_data.IsGrounded);
                _data.IsGrounded = false;
                return true;
            }
        }

        if (_data.IsStiff == true || _data.IsGrounded == false) //밀쳐진 상태   //그냥 공중에 있는 상태도 체크 필요
        {
            Debug.Log("점프 불가 ! ");
            return false;
        }
        else
        {
            Debug.Log("점프 가능 ! ");
            return true;
        }
    }
}
