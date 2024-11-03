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

    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private UiCommonSound _uiCommonSound;

    private void Awake()
    {
        BindAll();
    }

    private void Start()
    {
        //GetUI<Image>("CharacterText").gameObject.SetActive(false);

        // 새로 플레이 버튼 클릭 이벤트
        AddEvent("NewPlayButton", EventType.Click, NewGameStart);

        // 저장 플레이 버튼 클릭 이벤트
        AddEvent("LoadPlayButton", EventType.Click, LastGameStart);

        // 캐릭터 선택(오른쪽) 버튼 클릭 이벤트
        AddEvent("Character_Right", EventType.Click, NextCharacter);

        // 캐릭터 선택(왼쪽) 버튼 클릭 이벤트
        AddEvent("Character_Left", EventType.Click, PreviousCharacter);

        // 조작법 설명 버튼 클릭 이벤트
        AddEvent("ExplainButton", EventType.Click, ShowHowToPlay);

        // 나가기 버튼 클릭 이벤트
        AddEvent("ExitButton", EventType.Click, QuitGame);

        //버튼 사운드 이벤트 연결
        AddEvent("NewPlayButton", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("DifficultyUp", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("DifficultyDown", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("Character_Right", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("Character_Left", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("Character_Left", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("LoadPlayButton", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("ExplainButton", EventType.Click, _uiCommonSound.PlayCommonSound);

        AddEvent("ExitButton", EventType.Click, _uiCommonSound.PlayCommonSound);

        SetBGM();
    }

    private void Update()
    {
        // 조작법 설명 이미지가 활성화 되어있는 상태에서 ESC 키를 입력했을 경우
        if (_isImageActive = true && Input.GetKeyDown(KeyCode.Escape))
        {
            // 조작법 설명 이미지 오브젝트 비활성화
            GetUI<Image>("ExplainImage").gameObject.SetActive(false);
            // 이미지 활성화 체크 여부 false로 변경
            _isImageActive = false;
        }
    }

    private void SetBGM()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayeBGM(_audioClip);
    }

    // 새 게임 시작 버튼
    public void NewGameStart(PointerEventData eventData)
    {
        DataManager.Instance.ResetData();       // 저장된 게임 진행 데이터 리셋
        DataManager.Instance.SaveData.GameData.CharacterNum = (int)_characterNum;
        DataManager.Instance.SaveData.GameData.IsClear = false;
       _sceneChanger.ChangeScene("GameScene"); // 화면을 GameScene으로 전환
        Debug.Log("게임씬으로 넘어감!!!!!!!!!!!!!!!!!!!!");
    }

    // 저장된 게임 시작버튼
    public void LastGameStart(PointerEventData eventData)
    {
        DataManager.Instance.Load();
        _sceneChanger.ChangeScene("GameScene"); // 화면을 GameScene으로 전환
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
                GetUI<TextMeshProUGUI>("CharacterText").text = "Jumper";
                break;

            case ECharacterNum.Stone:
                Debug.Log("Stone");
                GetUI<TextMeshProUGUI>("CharacterText").text = "FlyingHead";
                break;

            case ECharacterNum.Jump:
                Debug.Log("Jump");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Bouncer";
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
