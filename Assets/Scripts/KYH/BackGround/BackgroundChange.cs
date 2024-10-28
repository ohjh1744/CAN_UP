using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] EnviromentManager _manager;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        StartCoroutine(CoBlendSkies());
    }

    // 스카이박스 블렌드 코루틴
    // 현재는 프로토타입 개발을 위해 블렌드가 아닌 단순 교체로 적용됨
    private IEnumerator CoBlendSkies()
    {
        // 플레이어의 y좌표값이 일정값 이상일 경우
        // _manager.BlendEnviroment("프리셋 이름", 전환 시간)
        if (_player.transform.position.y <= 15)
        {
            _manager.BlendEnviroment("Stage01", 2.0f);
        }
        else if (_player.transform.position.y <= 30)
        {
            _manager.BlendEnviroment("Stage02", 2.0f);
        }
        else if (_player.transform.position.y <= 45)
        {
            _manager.BlendEnviroment("Stage03", 2.0f);
        }
        else if (_player.transform.position.y <= 60)
        {
            _manager.BlendEnviroment("Stage04", 2.0f);
        }
        else if (_player.transform.position.y <= 75)
        {
            _manager.BlendEnviroment("Stage05", 2.0f);
        }
        yield return null;
    }
}
