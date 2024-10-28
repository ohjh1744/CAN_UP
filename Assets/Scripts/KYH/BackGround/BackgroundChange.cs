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

    private IEnumerator CoBlendSkies()
    {
        if (_player.transform.position.y <= 27)
        {
            _manager.BlendEnviroment("Day", 2.0f);
        }
        else if (_player.transform.position.y <= 54)
        {
            _manager.BlendEnviroment("Mid", 2.0f);
        }
        yield return null;
    }
}
