using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameSceneManager _gameSceneManager;

    [SerializeField] private Material[] _skyMaterials;

    private Coroutine _changeCamera;
    
    private void Start()
    {
        _gameSceneManager.Cameras[0].Priority = 1;
    
        for (int i = 0; i < _gameSceneManager.Cameras.Length - 1; i++)
        {
            _gameSceneManager.Cameras[i + 1].Priority = 0;
        }
    
        _player = GameObject.FindGameObjectWithTag("Player");
        RenderSettings.skybox = _skyMaterials[0];
    }
    
    private void Update()
    {
        StartCoroutine(ChangeCamera());
    }
    
    private IEnumerator ChangeCamera()
    {
        if (_player.transform.position.y <= 9.5f)
        {
            _gameSceneManager.Cameras[0].Priority = 1;
            _gameSceneManager.Cameras[1].Priority = 0;
            _gameSceneManager.Cameras[2].Priority = 0;
        }
        else if (_player.transform.position.y <= _gameSceneManager.StageHight[0])
        {
            _gameSceneManager.Cameras[0].Priority = 0;
            _gameSceneManager.Cameras[1].Priority = 1;
            _gameSceneManager.Cameras[2].Priority = 0;
            RenderSettings.skybox = _skyMaterials[0];
        }
        else if (_player.transform.position.y <= 37.5f)
        {
            _gameSceneManager.Cameras[0].Priority = 0;
            _gameSceneManager.Cameras[1].Priority = 0;
            _gameSceneManager.Cameras[2].Priority = 1;
            RenderSettings.skybox = _skyMaterials[1];
        }
        yield return null;
    }
}

