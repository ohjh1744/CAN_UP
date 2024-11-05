using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    [SerializeField] float _startJumpPositionY = 0.3f;

    [SerializeField] float _jumpPowerRate;

    [SerializeField] AudioSource _jumpAudio;

    [SerializeField] AudioSource _moveAudio;

    [SerializeField] AudioClip _audioClip;

    Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
    Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

    public override BTNodeState DoAction()
    {
        //차징 최대로, 최대점프력으로 점프
        if (_data.JumpPower >= _data.MaxJumpPower)
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
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space)) //Space를 누르고 있는 상태
        {
            _data.JumpPower += Time.deltaTime * _jumpPowerRate; //Space를 누르고 있으면 점프력이 상승함
            _animator.SetBool("isIdle", true);

            if (Input.GetKey(KeyCode.A)) // Space + A 키를 누르고 있을 때 
            {
                _rigidbody.velocity = Vector3.zero; // 멈춰서
                transform.forward = Vector3.left; // 왼쪽을 쳐다봄
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
            return BTNodeState.Running;
        }

        //좌로 점프
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.A)))) // A 누른 상태로 Space를 떼면 좌로 점프
        {
            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // 우로 점프
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.D))))
        {
            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // 수직 점프
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        else
        {
            if (_rigidbody.velocity.y < 0) // 낙하 시
            {
                Vector3 curVelocity = new Vector3(0, _rigidbody.velocity.y, 0); // 수직으로 떨어지게 함

                _rigidbody.velocity = curVelocity;
            }

            return BTNodeState.Failure;
        }
    }

    //점프 시 공통적으로 발생하는 함수
    public void JumpEvent()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _startJumpPositionY, transform.position.z);
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
        _data.JumpCount++;
        _jumpAudio.PlayOneShot(_audioClip);
    }
}
