using UnityEngine;

public class ActBaseWalk : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    Vector3 dir = new Vector3(-1, 0, 0);

    public override BTNodeState DoAction()
    {
        //좌로 이동
        if ((Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.Space)) //A 또는 D 키를 눌렀을 때, Space 입력하지 않았을 때 이동
        {
            _rigidbody.velocity = dir * _data.MoveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), _data.Rate * Time.deltaTime);
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.sqrMagnitude));
            _animator.SetBool("isIdle", false);
            return BTNodeState.Running;
        }
        //우로 이동
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = -dir * _data.MoveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-dir), _data.Rate * Time.deltaTime);
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.sqrMagnitude));
            _animator.SetBool("isIdle", false);
            return BTNodeState.Running;
        }
       
        //키 입력 없을때 멈춤
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("isIdle", true);
            _rigidbody.velocity = Vector3.zero;
            return BTNodeState.Success;
        }

        else
        {
            return BTNodeState.Failure;
        }
    }
}
