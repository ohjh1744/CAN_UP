using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour, IObjectPosition
{
    // 플레이어 및 아이템이 밀려나는 속도
    [SerializeField] private float _moveSpeed;

    // 플레이어의 Rigidbody 참조용 변수
    [SerializeField] private Rigidbody _rigid;

    // 레일 발판 기능 코루틴 변수(플레이어용)
    private Coroutine _railRoutine;

    // 이름 설정
    [SerializeField] string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // 레일 발판 기능 함수(플레이어)
    public void RailObstacle(PlayerController player)
    {
        // 플레이어의 Rigidbody 컴포넌트를 가져오기
        _rigid = player.gameObject.GetComponent<Rigidbody>();

        // 코루틴 값이 null인 경우 코루틴 진행
        if (_railRoutine == null )
        {
            _railRoutine = StartCoroutine(RailRoutine());
        }
    }

    // 레일 발판 기능 함수(아이템)
    public void RailObstacle(Item item)
    {
        // 플레이어의 Rigidbody 컴포넌트를 가져오기
        _rigid = item.gameObject.GetComponent<Rigidbody>();

        // 코루틴 값이 null인 경우 코루틴 진행
        if (_railRoutine == null)
        {
            _railRoutine = StartCoroutine(RailRoutine());
        }
    }

    // 레일 기능 코루틴
    private IEnumerator RailRoutine()
    {
        // 캐릭터 반대 방향으로 밀어내기
        _rigid.AddForce(Vector3.left * _moveSpeed, ForceMode.Impulse);
        // 밀어내는 타이밍 추가
        yield return new WaitForSeconds(0.2f);

        // 코루틴을 null로 처리
        _railRoutine = null;
    }
}
