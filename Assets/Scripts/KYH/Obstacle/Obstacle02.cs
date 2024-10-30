using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject _replaceObstacle;
    [SerializeField] private Rigidbody _rigid;

    private Coroutine _railRoutine;

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

    // 레일 기능 코루틴
    private IEnumerator RailRoutine()
    {
        // 캐릭터 반대 방향으로 밀어내기
        _rigid.AddForce(Vector3.left * _moveSpeed, ForceMode.Impulse);
        // 밀어내는 타이밍 추가
        yield return new WaitForSeconds(1.0f);

        // 코루틴을 null로 처리
        _railRoutine = null;
    }
}
