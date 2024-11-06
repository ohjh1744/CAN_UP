using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Bullet : MonoBehaviour
{
    // 부딪혔을 때 플레이어를 밀 힘
    [SerializeField] private float _pushForce;
    [SerializeField] private Vector3 _pushDir;

    // 이동 속도와 방향
    private Vector3 _direction;
    private float _speed;



    private void Start()
    {
        Destroy(gameObject, 5f); // 5초 후 파괴
    }

    public void Initialize(Vector3 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }

    private void Update()
    {
        // 발사 방향으로 이동
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void PushPlayer(PlayerController player)
    {
        // 플레이어의 rigid를 가져옴
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        rigid.AddForce(_pushDir * _pushForce, ForceMode.Impulse);

        Destroy(gameObject);
    }

    public void PushPlayer(Item item)
    {
        // 플레이어의 rigid를 가져옴
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        rigid.AddForce(_pushDir * _pushForce, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
