using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3 : MonoBehaviour, IObjectPosition
{
    [Header("폭발 설정")]

    [SerializeField] private float _explosionDelay; // 폭발까지 대기 시간
    [SerializeField] private float _explosionForce; // 폭발 강도
    [SerializeField] private float _resetDelay; // 발판 활성화 대기 시간

    // 폭발 경고 구체 오브젝트 배열
    [SerializeField] private GameObject[] _warningSpheres;

    // 폭발 여부 및 타이머
    [SerializeField] bool _isTriggered = false;
    [SerializeField] float _explosionTimer;

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
        _explosionTimer = _explosionDelay;
    }
    public void Count(PlayerController player)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            StartCoroutine(CountDown(player));
        }
    }

    private IEnumerator CountDown(PlayerController player)
    {
        while (_explosionTimer > 0)
        {
            _explosionTimer -= Time.deltaTime;

            // 2초 남았을 때 구체 하나 색 변경
            if (_explosionTimer <= 2f && _explosionTimer > 1f)
            {
                _warningSpheres[0].GetComponent<Renderer>().material.color = Color.red;
            }

            // 1초 남았을 때 하나 더 변경
            else if (_explosionTimer <= 1f && _explosionTimer > 0f)
            {
                _warningSpheres[1].GetComponent<Renderer>().material.color = Color.red;
            }

            _explosionTimer -= Time.deltaTime;
            yield return null;
        }

        // 폭발 실행
        _warningSpheres[2].GetComponent<Renderer>().material.color= Color.red;
        Explode(player);
    }

    private void Explode(PlayerController player)
    {
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        // 폭발할 각도 계산
        Vector3 explosionDir = (player.transform.position - transform.position).normalized;
        rigid.AddForce(explosionDir * _explosionForce, ForceMode.Impulse);

        // 비활성화 후 재활성화 시작
        gameObject.SetActive(false);
        Invoke(nameof(ResetPlatform), _resetDelay);
    }

    public void Count(Item item)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            StartCoroutine(CountDown(item));
        }
    }

    private IEnumerator CountDown(Item item)
    {
        while (_explosionTimer > 0)
        {
            _explosionTimer -= Time.deltaTime;

            // 2초 남았을 때 구체 하나 색 변경
            if (_explosionTimer <= 2f && _explosionTimer > 1f)
            {
                _warningSpheres[0].GetComponent<Renderer>().material.color = Color.red;
            }

            // 1초 남았을 때 하나 더 변경
            else if (_explosionTimer <= 1f && _explosionTimer > 0f)
            {
                _warningSpheres[1].GetComponent<Renderer>().material.color = Color.red;
            }

            _explosionTimer -= Time.deltaTime;
            yield return null;
        }

        // 폭발 실행
        _warningSpheres[2].GetComponent<Renderer>().material.color = Color.red;
        Explode(item);
    }

    private void Explode(Item item)
    {
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        // 폭발할 각도 계산
        Vector3 explosionDir = (item.transform.position - transform.position).normalized;
        rigid.AddForce(explosionDir * _explosionForce, ForceMode.Impulse);

        // 비활성화 후 재활성화 시작
        gameObject.SetActive(false);
        Invoke(nameof(ResetPlatform), _resetDelay);
    }

    private void ResetPlatform()
    {
        gameObject.SetActive(true);
        _isTriggered = false;
        _explosionTimer = _explosionDelay;

        // 경고 구체 색상 초기화
        foreach (var sphere in _warningSpheres)
        {
            sphere.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}