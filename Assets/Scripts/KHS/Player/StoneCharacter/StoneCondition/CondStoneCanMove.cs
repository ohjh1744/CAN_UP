using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondStoneCanMove : PlayerCondition
{
    [SerializeField] StoneData _data;
    [SerializeField] StoneRagdoll _ragdoll;
    [SerializeField] Animator _animator;
    [SerializeField] float stopSpeed;
    [SerializeField] LayerMask groundMask;

 
    public override bool DoCheck()
    {
        Debug.Log("두체크 시작");
        if(_ragdoll.SpeedRigdbody() > stopSpeed)
            return false;

        //if(_ragdoll.SpeedRigdbody() <= stopSpeed)
        //{
        //    _ragdoll.RagDollOff();
        //}
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Ray ray = new Ray(pos, Vector3.down);

        //Debug.Log("레이케스트 시작");
        if (Physics.Raycast(ray, out RaycastHit hit, _data.RayDistance, groundMask))
        {
            Debug.DrawRay(pos, Vector3.down * _data.RayDistance, Color.red, 1f);
            if(hit.collider.CompareTag("Ground") && _data.Flying == false)
            {
   
                Debug.Log($"{hit.collider.tag}감지됨");
                if(_data.StandAni == false)
                {
                    _animator.SetTrigger("StandUp");
                    _data.StandAni = true;
                }
                _ragdoll.RagDollOff();
                return true;
            }
        }
            
        _data.StandAni = false;
        return false;
    }
}
