using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] float _dropRayPosY = 0.1f;
    public override bool DoCheck()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _dropRayPosY, transform.position.z);
        Ray ray = new Ray(pos, Vector3.down);

        Debug.Log("레이케스트 시작");
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            Debug.DrawRay(pos, Vector3.down * 0.3f, Color.red);
            if (hit.collider.CompareTag("Ground"))
            {
                _data.IsGrounded = true;
                return true;
            }
        }
        else
        {
            _data.IsGrounded = false;
        }


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
}
