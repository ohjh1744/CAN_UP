using Unity.VisualScripting;
using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    public override bool DoCheck()
    {
        Debug.Log("작동 중");

        if (_data.IsStiff == true || _data.IsGrounded == false) //물리적으로 밀쳐진 상태
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _data.IsGrounded = true;
        }
    }
}
