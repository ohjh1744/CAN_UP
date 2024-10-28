using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] CinemachineVirtualCamera[] _cameras;


    private Coroutine _changeCamera;

    private void Start()
    {
        Debug.Log("ddd");
        _cameras[0].Priority = 1;

        Debug.Log("dddd");
        for (int i = 0; i < _cameras.Length - 1; i++)
        {
            _cameras[i + 1].Priority = 0;
        }

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        StartCoroutine(ChangeCamera());
    }

    private IEnumerator ChangeCamera()
    {
        if (_player.transform.position.y <= 7.5f)
        {
            _cameras[0].Priority = 1;
            _cameras[1].Priority = 0;
            _cameras[2].Priority = 0;
        }
        else if (_player.transform.position.y <= 17.5f)
        {
            _cameras[0].Priority = 0;
            _cameras[1].Priority = 1;
            _cameras[2].Priority = 0;
        }
        else if (_player.transform.position.y <= 27.5f)
        {
            _cameras[0].Priority = 0;
            _cameras[1].Priority = 0;
            _cameras[2].Priority = 1;
        }
        yield return null;
    }
}

