using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour, IReplaceObstacle
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject _replaceObstacle;

    public void RailObstacle(PlayerController player)
    {
        // 플레이어 오브젝트를 감지
        // 플레이어 오브젝트를 발판에 OnTriggerStay 했을 때
        // 플레이어 오브젝트를 일정 속도로 지정 방향으로 밀기
        Rigidbody rigid = player.gameObject.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.left * _moveSpeed;
    }

    public void Replace()
    {
        gameObject.SetActive(false);
        _replaceObstacle.SetActive(true);
    }
}
