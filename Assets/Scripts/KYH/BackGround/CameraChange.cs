using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class CameraChange : MonoBehaviour
{
    // GameSceneManager 클래스 참조용
    [SerializeField] private GameSceneManager _gameSceneManager;

    // 스테이지 별 배경 스카이박스 메터리얼 저장용 배열
    [SerializeField] private Material[] _skyMaterials;

    Coroutine _cameraRoutine;

    private void Start()
    {
        // 시작 카메라를 0번째 VirtualCamera로 설정
        _gameSceneManager.Cameras[0].gameObject.SetActive(true);

        // 첫번째 카메라 이외의 VirtualCamera Priority 값을 0으로 설정하여 0번째 카메라로 시작하게 구현
        for (int i = 0; i < _gameSceneManager.Cameras.Length - 1; i++)
        {
            _gameSceneManager.Cameras[i + 1].gameObject.SetActive(false);
        }

        // CharacterNum 열거형이 0번째 항목일 때를 예외 처리
        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return;

        // 처음 스카이박스의 메터리얼 설정
        RenderSettings.skybox = _skyMaterials[0];
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    int index = 0;
    //    float cameraHeight = Camera.main.orthographicSize;
    //
    //    if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "Stone"
    //        || collider.gameObject.tag == "Jumper")
    //    {
    //        if (_gameSceneManager.CurrentPlayerPos.y > gameObject.transform.position.y)
    //        {
    //            _gameSceneManager.Cameras[index].Priority = 0;
    //            _gameSceneManager.Cameras[index + 1].Priority = 2;
    //            index++;
    //        }
    //        else if (_gameSceneManager.CurrentPlayerPos.y < gameObject.transform.position.y)
    //        {
    //            _gameSceneManager.Cameras[index].Priority = 2;
    //            _gameSceneManager.Cameras[index + 1].Priority = 0;
    //            index--;
    //        }
    //    }        
    //}

   //IEnumerator CameraRoutine()
   //{
   //
   //}

    private void LateUpdate()
    {
        // 카메라의 높이/2 값을 변수로 저장
        float cameraHeight = Camera.main.orthographicSize;
        Debug.Log($"Height : {cameraHeight}");
        
        // VirtualCamera 변경용 반복문
        for (int i = 0; i < _gameSceneManager.Cameras.Length; i++)
        {
            // 플레이어의 y좌표값이 i번째 카메라의 위쪽 경계선보다 높을 경우
            if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
            {
                // i가 VirtualCamera 저장용 배열값보다 클 경우 예외 처리
                if (i > _gameSceneManager.Cameras.Length)
                    return;

                _gameSceneManager.Cameras[i].gameObject.SetActive(false);      // i번째 카메라의 Priority값을 0으로 설정하여 후순위로 변경
                _gameSceneManager.Cameras[i + 1].gameObject.SetActive(true);  // i + 1번째 카메라의 Priority값을 2로 설정하여 우선 순위로 변경
            }
            // 플레이어의 y좌표값이 i번째 카메라의 위쪽 경계선 이하의 값일 경우
            else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
            {

                // i번째 카메라의 Priority값을 1로 설정하여 우선 순위로 변경
                _gameSceneManager.Cameras[i].gameObject.SetActive(true);

                // i가 (VirtualCamera 저장용 배열값 - 1)이 아닐 경우에 대한 조건 설정
                if (i != _gameSceneManager.Cameras.Length - 1)
                {
                    // i + 1번째 카메라의 Prioriy값을 0으로 설정하여 후순위로 변경
                    _gameSceneManager.Cameras[i + 1].gameObject.SetActive(false);
                }
                break;
            }
        }

        // 스카이박스 메터리얼 교체용 반복문
        for (int i = 0; i < _skyMaterials.Length; i++)
        {
            // 현재 플레이어의 y좌표값이 스테이지 변경값보다 높을 경우
            if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 1]
                && _gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 2])
            {
                Debug.Log("sadgasdge");
                // i번째(다음 스테이지) 스카이박스 메터리얼로 스카이박스를 변경
                RenderSettings.skybox = _skyMaterials[i + 1];
                return;
            }
            //// 현재 플레이어의 y좌표값이 스테이지 변경값 이하일 경우
            //else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 1]
            //    && _gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 2])
            //{
            //    // i - 1번째(이전 스테이지) 스카이박스 메터리얼로 스카이박스를 변경
            //    RenderSettings.skybox = _skyMaterials[i];
            //}
        }
    }
}

