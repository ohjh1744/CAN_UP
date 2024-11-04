using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle10 : MonoBehaviour, IObjectPosition
{
    // reset()에 사용하기 위해 원래 위치 저장 변수
    [SerializeField] Vector3 _startPos;

    // 발판이 사라졌는지 여부 확인용 변수
    [SerializeField] bool _isPlatformDestroyed;

    // 사라지는 시간
    [SerializeField] float _disappearTime;


    // 재생성 타이머
    [SerializeField] float _respawnDelay;

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

    private void Start()
    {
        _startPos = transform.position;
        _isPlatformDestroyed = false;
    }

    public void Disappear(PlayerController player)
    {
        if (!_isPlatformDestroyed)
        {
            Invoke(nameof(DestroyPlatform), _disappearTime);
        }
    }
    public void Disappear(Item item)
    {
        if (!_isPlatformDestroyed)
        {
            Invoke(nameof(DestroyPlatform), _disappearTime);
        }
    }

    private void DestroyPlatform()
    {
        gameObject.SetActive(false);
        _isPlatformDestroyed = true;

        Invoke(nameof(ResetPlatform), _respawnDelay);
    }

    private void ResetPlatform()
    {
        gameObject.SetActive(true);
        _isPlatformDestroyed = false;
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