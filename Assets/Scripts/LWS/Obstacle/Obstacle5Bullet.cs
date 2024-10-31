using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Bullet : MonoBehaviour
{
    // 부딪혔을 때 플레이어를 밀 힘
    [SerializeField] private float pushForce;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void PushPlayer(PlayerController player)
    {
        // 플레이어의 rigid를 가져옴
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        Vector3 pushDir = (rigid.transform.position - transform.position).normalized;
        rigid.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }

    public void PushPlayer(Item item)
    {
        // 플레이어의 rigid를 가져옴
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        Vector3 pushDir = (rigid.transform.position - transform.position).normalized;
        rigid.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }
}
