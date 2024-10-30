using UnityEngine;

public class CondStoneCanMove : PlayerCondition
{
    // 플레이어 데이터
    [SerializeField] StoneData _data;
    //[SerializeField] StoneRagdoll _ragdoll;

    // 부모 리지드바디
    [SerializeField] Rigidbody _rb;
    [SerializeField] GameObject _parentObj;
    [SerializeField] GameObject _rayPoint;

    // 멈추는 속도
    [SerializeField] float stopSpeed;

    // 땅을 감지하는 레이어 마스크
    [SerializeField] LayerMask groundMask;

    private bool hit;

    //[SerializeField] Transform _parent;


    public override bool DoCheck()
    {
        Debug.Log("DoCheck 시작");

        if (_rb.velocity.magnitude > stopSpeed)
            return false;

        // 플레이어의 포지션
        //Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // 아래방향으로 Ray
        Ray ray = new Ray(_rayPoint.transform.position, Vector3.down);

        //Debug.Log("레이케스트 시작");
        if (Physics.Raycast(ray, out RaycastHit hit, _data.RayDistance, groundMask))
        {
            Debug.DrawRay(_rayPoint.transform.position, Vector3.down * _data.RayDistance, Color.yellow, 1f);
            if (hit.collider.CompareTag("Ground") && _data.Flying == false)
            {

                Debug.Log($"{hit.collider.tag}감지됨");
                _data.Animator.SetBool("Flying", false);
                //if(_data.StandAni == false)
                //{
                //    _animator.SetTrigger("StandUp");
                //    _data.StandAni = true;
                //}
                //_ragdoll.RagDollOff();
                ////_parent.position = new Vector3(_parent.position.x, hit.point.y, _parent.position.z);
                _rb.velocity = Vector3.zero;
                _parentObj.transform.position = new Vector3(_parentObj.transform.position.x, _parentObj.transform.position.y,0);
                return true;
            }
        }

        return false;
    }
}
