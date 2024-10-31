using Cinemachine;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneManager : UIBInder
{
    private StringBuilder _sb = new StringBuilder();

    // 세이브 포인트 배열
    [SerializeField] private Vector3[] _savePoints;
    public Vector3[] SavePoints { get { return _savePoints; } set { _savePoints = value; } }

    // 스테이지 높이 배열
    [SerializeField] private float[] _stageHight;
    public float[] StageHight { get { return _stageHight; } set { _stageHight = value; } }

    // 카메라 배열
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    public CinemachineVirtualCamera[] Cameras { get { return _cameras; } set { _cameras = value; } }

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

    // 시네머신 브레인 이벤트 함수에 활용할 시네머신 브레인
    [SerializeField] private CinemachineBrain _brain;
    public CinemachineBrain Brain { get { return _brain; } set { _brain = value; } }

    // esc 누를 때 나올 패널
    [SerializeField] private GameObject _escPanel;

    public GameObject EscPanel { get { return _escPanel; } set { _escPanel = value; } }

    // 씬체인저
    [SerializeField] private SceneChanger _sceneChanger;

    public SceneChanger SceneChanger { get { return _sceneChanger; } set { _sceneChanger = value; } }

    private void Awake()
    {
        _brain = Camera.main.GetComponent<CinemachineBrain>();
        BindAll();
    }

    private void OnEnable()
    {
        DataManager.Instance.SaveData.GameData.OnJumpTimeChange += UpdateJumpTime;
        DataManager.Instance.SaveData.GameData.OnFallTimeChange += UpdateFallTime;
        DataManager.Instance.SaveData.GameData.OnPlayTimeChange += UpdatePlayTime;
    }

    private void OnDisable()
    {
        DataManager.Instance.SaveData.GameData.OnJumpTimeChange -= UpdateJumpTime;
        DataManager.Instance.SaveData.GameData.OnFallTimeChange -= UpdateFallTime;
        DataManager.Instance.SaveData.GameData.OnPlayTimeChange -= UpdatePlayTime;
    }

    private void Start()
    {
        AddEvent("ResumeButton", EventType.Click, ResumeGame);
        AddEvent("SaveExitButton", EventType.Click, SaveAndQuitGame);
        AddEvent("MainButton", EventType.Click, GiveUpGame);

        SetGame(DataManager.Instance);
    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _escPanel.SetActive(true);
        }

        CheckState(DataManager.Instance);
    }

   

    private void SetGame(DataManager dataManager)
    {
        // 0. 초기화 되어야 하는 기본 변수
        _item.transform.position = _savePoints[1];

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
        // 0. 계속 갱신되어야 하는 기본 변수
        // 현재 포지션
        _currentPlayerPos = _players[dataManager.SaveData.GameData.CharacterNum].transform.position;

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
        if (_currentSaveStage > _currentStage)
        {
            _currentSaveStage = _currentStage;
        }

        // 3. CheckResetObject
        CheckResetObject();

        // 4. Item위치 체크 후 갱신
        if (!dataManager.SaveData.GameData.HasItem)
        {
            if (_item.transform.position.y < _stageHight[_currentStage])
            {
                _item.transform.position = _savePoints[_currentStage];
            }
        }
    }

    private void ResumeGame(PointerEventData eventData)
    {
        Time.timeScale = 1;
        _escPanel.SetActive(false);
    }

    private void SaveAndQuitGame(PointerEventData eventData)
    {
        DataManager.Instance.SaveData.GameData.IsClear = false;
        DataManager.Instance.SaveData.GameData.PlayerStage = _currentStage;
        DataManager.Instance.SaveData.GameData.HasItem = false;
        DataManager.Instance.SaveData.GameData.ItemStage = _currentStage;
        //DataManager.Instance.SaveData.GameData.PlayTime;
        Application.Quit();
    }

    private void GiveUpGame(PointerEventData eventData)
    {
        _sceneChanger.ChangeScene("MainScene");
        _escPanel.SetActive(false);
    }

    // 시네머신 브레인 이벤트 함수 실행해서 카메라가 변경될 때 마다 Reset()
    private void CheckResetObject()
    {
        _brain.m_CameraActivatedEvent.AddListener(Reset1);

        void Reset1(ICinemachineCamera forecamera, ICinemachineCamera toCamera)
        {
            for (int i = 0; i < _resetObjects.Length; i++)
            {
                foreach (IResetObject j in _resetObjects)
                {
                    j.Reset();
                }
            }
        }
    }

    // 시작 캐릭터가 Base가 아닐 경우, Replace가 필요한 Obstacle들 대체 실행
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

    private void UpdateJumpTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.JumpTime);
        GetUI<TextMeshProUGUI>("JumpTime").SetText(_sb);
    }
    private void UpdateFallTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.FallTime);
        GetUI<TextMeshProUGUI>("FallTime").SetText(_sb);
    }
    private void UpdatePlayTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.PlayTime);
        GetUI<TextMeshProUGUI>("PlayTime").SetText(_sb);
    }
}
