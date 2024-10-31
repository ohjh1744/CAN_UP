using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    // SceneChanger 클래스 참조용
    [SerializeField] private SceneChanger _sceneChanger { get; }

    // SaveData 클래스 참조용
    [SerializeField] private GameData _gameData { get; set; }

    // DataManager 클래스 참조용
    [SerializeField] private DataManager _dataManager { get; }

    // 조작법 설명용 이미지 오브젝트
    [SerializeField] private GameObject _explainImage;

    // 조작법 설명용 이미지 활성화 여부 체크
    [SerializeField] private bool _isImageActive;

    // 게임 난이도 표시 텍스트 모음 배열
    [SerializeField] private GameObject[] _difficultyTexts;

    // 게임 캐릭터 표시 텍스트 모음 배열
    [SerializeField] private GameObject[] _characterTexts;

    private void Start()
    {
        _difficultyTexts[0].SetActive(false);
        _difficultyTexts[1].SetActive(true);
        _difficultyTexts[2].SetActive(false);
        _explainImage.SetActive(false); // 조작법 설명 이미지 오브젝트를 비활성화
        _isImageActive = false;         // 이미지 활성화 여부를 false로 체크
    }

    private void Update()
    {
        // 조작법 이미지가 활성화 되어 있으면서 ESC 키를 입력했을 경우
        if (_isImageActive == true && Input.GetKeyDown(KeyCode.Escape))
        {
            _explainImage.SetActive(false); // 조작법 설명 이미지 오브젝트를 비활성화
            _isImageActive = false;         // 이미지 활성화 여부를 false로 체크
        }
    }

    // 새 게임 시작 버튼
    public void NewGameStart()
    {
        _dataManager.ResetData();               // 저장된 게임 진행 데이터 리셋
        _sceneChanger.ChangeScene("GameScene"); // 화면을 GameScene으로 전환
    }

    // 진행 중인 게임 시작 버튼
    public void LastGameStart()
    {
        // 저장된 게임을 불러와야 하기 때문에 데이터 리셋 불필요
        _sceneChanger.ChangeScene("GameScene"); // 화면을 GameScene으로 전환
    }

    // 게임 조작법 안내 버튼
    public void ShowHowToPlay()
    {
        _explainImage.SetActive(true);  // 조작법 설명 이미지 오브젝트를 활성화
        _isImageActive = true;          // 이미지 활성화 여부를 true로 체크
    }

    // 다음 캐릭터 선택 버튼
    public void NextCharacter()
    {
        if (_gameData.IsClear == false)
            return;


    }

    // 이전 캐릭터 선택 버튼
    public void PreviousCharacter()
    {

    }

    // 다음 난이도 선택 버튼
    public void NextDifficulty()
    {

    }

    // 이전 난이도 선택 버튼
    public void PreviousDifficulty()
    {

    }

    // 게임 종료 버튼
    public void QuitGame()
    {
        _sceneChanger.QuitGame();   // SceneChanger에서 게임 종료 함수 호출
    }
}
