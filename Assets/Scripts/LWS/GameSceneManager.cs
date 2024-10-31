using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // 세이브 포인트 배열
    [SerializeField] private Vector3[] _savePoints;
    public Vector3[] SavePoints { get { return _savePoints; } set { _savePoints = value; } }

    // 스테이지 높이 배열
    [SerializeField] private float[] _stageHight;
    public float[] StageHight { get { return _stageHight; } set { _stageHight = value; } }

    // 카메라 배열
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    public CinemachineVirtualCamera[] Cameras { get { return _cameras; } set { _cameras = value; } }

    // 카메라 현재 인덱스
    [SerializeField] private int _curCameraIndex;
    public int CurCameraIndex { get { return _curCameraIndex; } set { _curCameraIndex = value; } }

    // 카메라 과거 인덱스
    [SerializeField] private int _preCameraIndex;
    public int PreCameraIndex { get { return _preCameraIndex; } set { _preCameraIndex = value; } }

    // 현재 플레이어 포지션
    [SerializeField] private Vector3 _currentPlayerPos;
    public Vector3 CurrentPlayerPos { get { return _currentPlayerPos; } set { _currentPlayerPos = value; } }

    // 현재 스테이지
    [SerializeField] private int _currentStage;
    public int CurrentStage { get { return _currentStage; } set { _currentStage = value; } }

    // 현재 저장된 스테이지
    [SerializeField] private int _currentSaveStage;
    public int CurrentSaveStage { get { return _currentStage; } set { _currentStage = value; } }

    // 아이템
    [SerializeField] private GameObject _item;
    public GameObject Item { get { return _item; } set { _item = value; } }

    // 캐릭터들
    [SerializeField] private GameObject[] _players;
    public GameObject[] Players { get { return _players; } set { _players = value; } }

    // 리셋 기믹들
    [SerializeField] private IResetObject[] _resetObjects;
    public IResetObject[] ResetObjects { get { return _resetObjects; } set { _resetObjects = value; } }

    // 대체 기믹들
    [SerializeField] private IReplaceObstacle[] _replaceObstacles;
    public IReplaceObstacle[] ReplaceObstacles { get { return _replaceObstacles; } set { _replaceObstacles = value; } }

    private void SetGame(DataManager dataManager)
    {
        // 1. 저장된 savestage 가져오기
        // 현재 스테이지 및 저장된 스테이지를 저장된 playerStage로 지정
        _currentStage = dataManager.SaveData.GameData.PlayerStage;

        // 저장된 캐릭터를 세이브포인트에 소환
        _players[dataManager.SaveData.GameData.CharacterNum].transform.position = _savePoints[_currentSaveStage];

        // 2. Item 위치 가져오기
        if (dataManager.SaveData.GameData.CharacterNum == 1)
        {
            _item.transform.position = _players[dataManager.SaveData.GameData.CharacterNum].transform.position;
        }

        // 3. CheckReplaceObject 실행 (?)
        CheckReplaceObstacle(dataManager);

        // 4. 캐릭터 가져오기
        _players[dataManager.SaveData.GameData.CharacterNum].SetActive(true);
    }
    private void CheckState(DataManager dataManager)
    {
        // 1. currentStage 갱신
        for (int i = 0; i < (int)EStage.Length; i++)
        {
            if (_stageHight[i] <= _players[dataManager.SaveData.GameData.CharacterNum].transform.position.y &&
                _players[dataManager.SaveData.GameData.CharacterNum].transform.position.y < _stageHight[i + 1])
            {
                _currentStage = i + 1;
                break;
            }
        }

        // 2. SavePoint 변경 (?)
        if ( _currentSaveStage > _currentStage )
        {
            _currentSaveStage = _currentStage;
        }
        
        // 3. CheckResetObject
    }

    private void ResumeGame()
    {

    }

    private void SaveAndQuitGame()
    {

    }

    private void GiveUpGame()
    {

    }

    private void CheckResetObject()
    {

    }

    private void CheckReplaceObstacle(DataManager dataManager)
    {
        if (dataManager.SaveData.GameData.CharacterNum == 2 || dataManager.SaveData.GameData.CharacterNum == 3)
        {
            for (int i = 0; i < _replaceObstacles.Length; i++)
            {
                foreach (IReplaceObstacle j in _replaceObstacles)
                {
                    j.Replace();
                }
            }
        }
    }

    private void Awake()
    {

    }
}
