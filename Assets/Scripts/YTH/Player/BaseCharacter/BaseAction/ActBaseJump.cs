using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    public override BTNodeState DoAction()
    {
        Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
        Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space 누르고 있는 상태
        {
            _data.JumpPower += Time.deltaTime * 6f;  // 점프력 상승중
            Debug.Log("점프력 차징 중");

            //점프력 최대 도달 시 수직 점프
            if (_data.JumpPower >= _data.MaxJumpPower)
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            return BTNodeState.Running;
        }

        //좌로 점프
        else if ((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKey(KeyCode.A)))
        {
            //점프력 최대 도달 시 (최대 점프력으로) 좌로 점프
            if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.A)))                      
            {                                                                                            //조건문 수정해서 점프력 차징이 A/D 키 눌렀을때 계속 이어지게 수정
                _data.JumpPower = _data.MaxJumpPower;                                                    //점프력 적용 문제
                _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // 우로 점프
        else if ((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKey(KeyCode.D)))
        {
            //점프력 최대 도달 시 (최대 점프력으로) 우로 점프
            if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.D)))
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
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
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
    }
}
