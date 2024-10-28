using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    public override bool DoCheck()
    {
        if (_data.IsStiff == true)
        {
            Ray ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _data.GroundCheckDistance))
            {
                if (hitInfo.collider.CompareTag("Ground"))
                {
                    Debug.Log(_data.IsGrounded);
                    return true;
                }
            }
            return false;
        }
        else
        {
            return true;
        }
    }
}
