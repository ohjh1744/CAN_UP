using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    [SerializeField] float _startJumpPositionY = 0.3f;
    public override BTNodeState DoAction()
    {
        Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
        Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

        //점프 차징 맥스, 최대점프력으로 점프
        if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space)))
        {
            _data.JumpPower = _data.MaxJumpPower;

            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            }
            else
            {
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            }
            JumpEvent();
            Debug.Log("최대 점프");
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space))// space 누르고 있는 상태
        {

            _data.JumpPower += Time.deltaTime * 6f;
            //회전 적용
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.right;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.back;
            }
            Debug.Log("점프력 차징 중");
            return BTNodeState.Running;
        }

        //좌로 점프
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.A) || (Input.GetKeyUp(KeyCode.A)))))
        {
            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("좌로 살짝 점프");
            return BTNodeState.Success;
        }

        // 우로 점프
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.D) || (Input.GetKeyUp(KeyCode.D)))))
        {
            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("우로 살짝 점프");
            return BTNodeState.Success;
        }

        // 수직 점프
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("수직 살짝 점프");
            return BTNodeState.Success;
        }



        else
        {
            return BTNodeState.Failure;
        }
    }

    //점프 시 공통적으로 발생하는 함수
    public void JumpEvent()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
    }
}
