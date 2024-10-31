using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneManager : UIBInder
{
    // SceneChanger 클래스 참조용
    [SerializeField] private SceneChanger _sceneChanger;

    // 조작법 설명용 이미지 오브젝트
    [SerializeField] private GameObject _explainImage;

    // 조작법 설명용 이미지 활성화 여부 체크
    [SerializeField] private bool _isImageActive;

    [SerializeField] private ECharacterNum _characterNum;

    private void Awake()
    {
        BindAll();
    }

    private void Start()
    {
        //GetUI<Image>("CharacterText").gameObject.SetActive(false);

        AddEvent("NewPlay Button", EventType.Click, NewGameStart);

        AddEvent("LoadPlay Button", EventType.Click, LastGameStart);

        AddEvent("Character_Right", EventType.Click, NextCharacter);

        AddEvent("Character_Left", EventType.Click, PreviousCharacter);

        AddEvent("Explain Button", EventType.Click, ShowHowToPlay);

        AddEvent("Exit Button", EventType.Click, QuitGame);
    }

    private void Update()
    {
        if (_isImageActive = true && Input.GetKeyDown(KeyCode.Escape))
        {
            GetUI<Image>("ExplainImage").gameObject.SetActive(false);
            _isImageActive = false;
        }
    }

    // 새 게임 시작 버튼
    public void NewGameStart(PointerEventData eventData)
    {
        DataManager.Instance.ResetData();       // 저장된 게임 진행 데이터 리셋
        DataManager.Instance.SaveData.GameData.CharacterNum = (int)_characterNum;
        _sceneChanger.ChangeScene("LWS"); // 화면을 GameScene으로 전환
    }

    // 진행 중인 게임 시작 버튼
    public void LastGameStart(PointerEventData eventData)
    {
        //DataManager.Instance.Load();
        _sceneChanger.ChangeScene("LWS"); // 화면을 GameScene으로 전환
    }

    // 게임 조작법 안내 버튼
    public void ShowHowToPlay(PointerEventData eventData)
    {
        GetUI<Image>("ExplainImage").gameObject.SetActive(true);
        //_explainImage.SetActive(true);  // 조작법 설명 이미지 오브젝트를 활성화
        _isImageActive = true;          // 이미지 활성화 여부를 true로 체크
    }

    // 다음 캐릭터 선택 버튼
    public void NextCharacter(PointerEventData eventData)
    {
        if (_characterNum == ECharacterNum.Length - 1)
            return;

        _characterNum++;

        switch (_characterNum)
        {
            case ECharacterNum.Base:
                Debug.Log("Base");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Base";
                break;
        
            case ECharacterNum.Stone:
                Debug.Log("Stone");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Stone";
                break;
        
            case ECharacterNum.Jump:
                Debug.Log("Jump");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Jump";
                break;
        }
    }

    // 이전 캐릭터 선택 버튼
    public void PreviousCharacter(PointerEventData eventData)
    {
        if (_characterNum == ECharacterNum.Base)
            return;

        _characterNum--;

        switch (_characterNum)
        {
            case ECharacterNum.Base:
                Debug.Log("Base");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Base";
                break;

            case ECharacterNum.Stone:
                Debug.Log("Stone");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Stone";
                break;

            case ECharacterNum.Jump:
                Debug.Log("Jump");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Jump";
                break;
        }
    }

    // 다음 난이도 선택 버튼
    public void NextDifficulty(PointerEventData eventData)
    {
        // 추후 난이도 개발되면 추가 작성
    }

    // 이전 난이도 선택 버튼
    public void PreviousDifficulty(PointerEventData eventData)
    {
        // 추후 난이도 개발되면 추가 작성
    }

    // 게임 종료 버튼
    public void QuitGame(PointerEventData eventData)
    {
        _sceneChanger.QuitGame();   // SceneChanger에서 게임 종료 함수 호출
    }
}
