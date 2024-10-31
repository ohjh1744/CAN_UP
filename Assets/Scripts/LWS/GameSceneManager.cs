using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // 세이브 포인트 배열
    [SerializeField] private Vector3[] _savePoints;

    // 스테이지 높이 배열
    [SerializeField] private float[] _stageHight;

    // 카메라 배열
    [SerializeField] private CinemachineVirtualCamera[] _camera;

    // 현재 플레이어 포지션
    [SerializeField] private Vector3 _currentPlayerPos;

    // 현재 스테이지
    [SerializeField] private int _currentStage;

    // 현재 저장된 스테이지
    [SerializeField] private int _currentSaveStage;

    // 아이템
    [SerializeField] private GameObject _item;

    // 캐릭터들
    [SerializeField] private GameObject[] _players;

    // 리셋 기믹들
    [SerializeField] private IResetObject[] _resetObjects;

    // 대체 기믹들
    [SerializeField] private IReplaceObstacle[] _replaceObstacles;


    private void CheckResetObject()
    {
        // checkstate int
        // int >> 미리 저장 _preCameraIndex;
        // int >> 계속 변할 _curCameraIndex; 
    }
}
