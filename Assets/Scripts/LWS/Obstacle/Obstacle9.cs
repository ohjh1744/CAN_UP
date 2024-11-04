using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle9 : MonoBehaviour, IReplaceObstacle, IObjectPosition
{
    // 올라탔을 때 기믹이 발동할 (이 스크립트를 적용할) 트리거발판을 1번. 도망갈 발판을 2번이라고 부르겠음.
    // 콩콩이 캐릭터가 trigger enter와 exit을 판단할 수 있게 하기 위해, isTrigger인 콜라이더 적용 필요 (콩콩이의 점프높이보다 높아야함)
    // 2번 발판 rigidbody 중력 사용 체크 해제, is kinematic 체크 필요

    // 2번 발판 rigidbody
    [SerializeField] private Rigidbody _escapePlatform;

    // 속도 조절용 변수 ( 플레이어 속도를 받으려면 참조 필요 )
    [SerializeField] private float _moveSpeed;

    [SerializeField] GameObject _replaceObject;

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

    public void Runaway(PlayerController player)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(horizontalInput * _moveSpeed, 0, 0);
        _escapePlatform.velocity = moveDir;
    }
    public void Runaway(Item item)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(horizontalInput * _moveSpeed, 0, 0);
        _escapePlatform.velocity = moveDir;
    }

    public void Replace()
    {
        _replaceObject.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigid = collision.collider.GetComponent<Rigidbody>();
        if (rigid.velocity.y <= 0)
        {
            rigid.velocity = Vector3.down;
        }
    }
}
