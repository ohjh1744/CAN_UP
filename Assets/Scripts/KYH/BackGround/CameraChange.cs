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

        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return; 

        _player = _gameSceneManager.Players[DataManager.Instance.SaveData.GameData.CharacterNum];

        RenderSettings.skybox = _skyMaterials[0];
    }
    
    private void Update()
    {
        StartCoroutine(ChangeCamera());

        //float cameraHeight = Camera.main.orthographicSize;
        //
        //for (int i = 0; i < _gameSceneManager.Cameras.Length; i++)
        //{
        //    if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
        //    {
        //        if (i > _gameSceneManager.Cameras.Length)
        //            return;
        //
        //        _gameSceneManager.Cameras[i].Priority = 0;
        //        _gameSceneManager.Cameras[i + 1].Priority = 1;
        //
        //        if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 1])
        //        {
        //            RenderSettings.skybox = _skyMaterials[i + 1];
        //        }
        //    }
        //    else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
        //    {
        //        if (i < 0)
        //            return;
        //
        //        _gameSceneManager.Cameras[i].Priority = 1;
        //        _gameSceneManager.Cameras[i + 1].Priority = 0;
        //
        //        if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i])
        //        {
        //            RenderSettings.skybox = _skyMaterials[i];
        //        }
        //    }
        //}
    }

    private IEnumerator ChangeCamera()
    {
        float cameraHeight = Camera.main.orthographicSize;

        if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[0].transform.position.y + cameraHeight)
        {
            _gameSceneManager.Cameras[0].Priority = 1;
            _gameSceneManager.Cameras[1].Priority = 0;
            _gameSceneManager.Cameras[2].Priority = 0;
        }
        else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[1].transform.position.y + cameraHeight)
        {
            _gameSceneManager.Cameras[0].Priority = 0;
            _gameSceneManager.Cameras[1].Priority = 1;
            _gameSceneManager.Cameras[2].Priority = 0;
            RenderSettings.skybox = _skyMaterials[0];
        }
        else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[2].transform.position.y + cameraHeight)
        {
            _gameSceneManager.Cameras[0].Priority = 0;
            _gameSceneManager.Cameras[1].Priority = 0;
            _gameSceneManager.Cameras[2].Priority = 1;
            RenderSettings.skybox = _skyMaterials[1];
        }
        yield return null;
    }
}

