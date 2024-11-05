using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class MaterialChanger : MonoBehaviour
{
    // GameSceneManager 클래스 참조용
    [SerializeField] private GameSceneManager _gameSceneManager;

    // 스테이지 별 배경 스카이박스 메터리얼 저장용 배열
    [SerializeField] private Material[] _skyMaterials;

    private void Start()
    {
        // CharacterNum 열거형이 0번째 항목일 때를 예외 처리
        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return;

        // 처음 스카이박스의 메터리얼 설정
        RenderSettings.skybox = _skyMaterials[0];
    }

    private void Update()
    {
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

