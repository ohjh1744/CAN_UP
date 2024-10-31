using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    [SerializeField] private Material[] _materials;
    [SerializeField] private float[] _stageHight;


    private Coroutine _changeCamera;

    private void Start()
    {
        _cameras[0].Priority = 1;

        for (int i = 0; i < _cameras.Length - 1; i++)
        {
            _cameras[i + 1].Priority = 0;
        }

        _player = GameObject.FindGameObjectWithTag("Player");
        RenderSettings.skybox = _materials[0];
    }

    private void Update()
    {
        StartCoroutine(ChangeCamera());
    }

    private IEnumerator ChangeCamera()
    {
        if (_player.transform.position.y <= 9.5f)
        {
            _cameras[0].Priority = 1;
            _cameras[1].Priority = 0;
            _cameras[2].Priority = 0;
        }
        else if (_player.transform.position.y <= _stageHight[0])
        {
            _cameras[0].Priority = 0;
            _cameras[1].Priority = 1;
            _cameras[2].Priority = 0;
            RenderSettings.skybox = _materials[0];
        }
        else if (_player.transform.position.y <= 37.5f)
        {
            _cameras[0].Priority = 0;
            _cameras[1].Priority = 0;
            _cameras[2].Priority = 1;
            RenderSettings.skybox = _materials[1];
        }
        yield return null;
    }
}

