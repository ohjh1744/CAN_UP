using Cinemachine;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneContext: UIBInder
{
    private StringBuilder _sb = new StringBuilder();

    // ĳ���� ���� ������
    [SerializeField] private float _savePointYOffset;

    // ������ ���� ������
    [SerializeField] private float _itemPointXOffset;

    // ���̺� ����Ʈ �迭
    [SerializeField] private Vector3[] _savePoints;
    public Vector3[] SavePoints { get { return _savePoints; } set { _savePoints = value; } }

    // �������� ���� �迭
    [SerializeField] private float[] _stageHight;
    public float[] StageHight { get { return _stageHight; } set { _stageHight = value; } }

    // ī�޶� �迭
    //[SerializeField] private CinemachineVirtualCamera[] _cameras;
    //public CinemachineVirtualCamera[] Cameras { get { return _cameras; } set { _cameras = value; } }

    // ���� �÷��̾� ������
    [SerializeField] private Vector3 _currentPlayerPos;
    public Vector3 CurrentPlayerPos { get { return _currentPlayerPos; } set { _currentPlayerPos = value; } }

    // ���� ��������
    [SerializeField] private int _currentStage;
    public int CurrentStage { get { return _currentStage; } set { _currentStage = value; } }

    // ���� ����� ��������
    [SerializeField] private int _currentSaveStage;
    public int CurrentSaveStage { get { return _currentSaveStage; } set { _currentSaveStage = value; } }

    // ������
    [SerializeField] private GameObject _item;
    public GameObject Item { get { return _item; } set { _item = value; } }

    // ĳ���͵�
    [SerializeField] private GameObject[] _players;
    public GameObject[] Players { get { return _players; } set { _players = value; } }

    // ���� ��͵�
    [SerializeField] private GameObject[] _resetObjects;
    public GameObject[] ResetObjects { get { return _resetObjects; } set { _resetObjects = value; } }

    // ��ü ��͵�
    [SerializeField] private GameObject[] _replaceObstacles;
    public GameObject[] ReplaceObstacles { get { return _replaceObstacles; } set { _replaceObstacles = value; } }

    // �ó׸ӽ� �극�� �̺�Ʈ �Լ��� Ȱ���� �ó׸ӽ� �극��
    //[SerializeField] private CinemachineBrain _brain;
    //public CinemachineBrain Brain { get { return _brain; } set { _brain = value; } }

    // esc ���� �� ���� �г�
    [SerializeField] private GameObject _escPanel;

    public GameObject EscPanel { get { return _escPanel; } set { _escPanel = value; } }

    [SerializeField] private GameObject _clearPanel;

    public GameObject ClearPanel { get { return _clearPanel; } private set { } }

    // ��ü����
    [SerializeField] private SceneChanger _sceneChanger;

    public SceneChanger SceneChanger { get { return _sceneChanger; } set { _sceneChanger = value; } }

    private float _curPlayTime;

    [SerializeField] private AudioClip[] _audioClips;

    [SerializeField] private AudioClip _audioClear;

    private AudioClip _curAudioClip;

    [SerializeField] private UiCommonSound _uiCommonSound;

    private void Awake()
    {
        //_brain = Camera.main.GetComponent<CinemachineBrain>();
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
        AddEvent("GiveUpButton", EventType.Click, GoToMain);
        AddEvent("MainButton", EventType.Click, GoToMain);

        SetGame();
        UpdateJumpTime();
        UpdateFallTime();
        _curAudioClip = null;

        //���� ó��
        AddEvent("ResumeButton", EventType.Click, _uiCommonSound.PlayCommonSound);
        AddEvent("SaveExitButton", EventType.Click, _uiCommonSound.PlayCommonSound);
        AddEvent("GiveUpButton", EventType.Click, _uiCommonSound.PlayCommonSound);
        AddEvent("MainButton", EventType.Click, _uiCommonSound.PlayCommonSound);
    }



    private void Update()
    {

        //���࿡ ������ ���� �÷����� ��� isClear�� �����ٸ� clear Panel �����鼭 time stop.
        if (DataManager.Instance.SaveData.GameData.IsClear == true)
        {
            Time.timeScale = 0f;
            ClearPanel.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Escape) && _escPanel.activeSelf == false)
        {
            SoundManager.Instance.PlaySFX(_uiCommonSound.AudioClip);
            Time.timeScale = 0;
            _escPanel.SetActive(true);
        }

        CheckState();
        SetBGM();
        CheckPlayTime();

    }


    private void SetBGM()
    {
        switch (_currentStage)
        {
            case (int)EStage.First:
                AudioClip audioClip = _audioClips[(int)EStage.First];
                if (_curAudioClip != audioClip)
                {
                    _curAudioClip = audioClip;
                    SoundManager.Instance.PlayeBGM(_audioClips[(int)EStage.First]);
                }
                break;
            case (int)EStage.Second:
                audioClip = _audioClips[(int)EStage.Second];
                if (_curAudioClip != audioClip)
                {
                    _curAudioClip = audioClip;
                    SoundManager.Instance.PlayeBGM(_audioClips[(int)EStage.Second]);
                }
                break;
            case (int)EStage.Third:
                audioClip = _audioClips[(int)EStage.Third];
                if (_curAudioClip != audioClip)
                {
                    _curAudioClip = audioClip;
                    SoundManager.Instance.PlayeBGM(_audioClips[(int)EStage.Third]);
                }
                break;
            case (int)EStage.Fourth:
                audioClip = _audioClips[(int)EStage.Fourth];
                if (_curAudioClip != audioClip)
                {
                    _curAudioClip = audioClip;
                    SoundManager.Instance.PlayeBGM(_audioClips[(int)EStage.Fourth]);
                }
                break;
        }
    }

    private void SetGame()
    {
        // 0. �ʱ�ȭ �Ǿ�� �ϴ� �⺻ ����
        _item.transform.position = _savePoints[1];

        // 1. ����� savestage ��������
        // ����� ���������� ����� playerStage�� ����
        _currentSaveStage = DataManager.Instance.SaveData.GameData.PlayerStage;

        // ���� ���������� ����Ƚ��������� �����ϰ� ����.
        _currentStage = _currentSaveStage;

        // y������ savePOint�����Ͽ� Player�� platform �浹����
        Vector3 _newSavePoint = new Vector3(_savePoints[_currentSaveStage].x, _savePoints[_currentSaveStage].y + _savePointYOffset, _savePoints[_currentSaveStage].z);

        // ����� ĳ���͸� ���̺�����Ʈ�� ��ȯ
        _players[DataManager.Instance.SaveData.GameData.CharacterNum].transform.position = _newSavePoint;

        // x����������� itemPoint�����Ͽ� Player�� item �浹����
        Vector3 _newItemPoint = new Vector3(_savePoints[_currentSaveStage].x + _itemPointXOffset, _savePoints[_currentSaveStage].y + 2, _savePoints[_currentSaveStage].z);

        // 2. Item ��ġ ��������
        if (DataManager.Instance.SaveData.GameData.CharacterNum == 1)
        {
            _item.transform.position = _newItemPoint;
        }
        else
        {
            _item.SetActive(false);
        }

        // 3. CheckReplaceObject ���� (?)
        CheckReplaceObstacle();

        // 4. ĳ���� ��������
        _players[DataManager.Instance.SaveData.GameData.CharacterNum].SetActive(true);

        // 5. ī�޶� ������ ��������
        Camera.main.transform.position = DataManager.Instance.SaveData.GameData.CameraPos;
    }

    private void CheckState()
    {

        // 0.���� ������
        _currentPlayerPos = _players[DataManager.Instance.SaveData.GameData.CharacterNum].transform.position;

        // 1. SavePoint ���� �����ϰ� �ɽ� _currentSaveStage ����.
        if (_currentSaveStage > _currentStage)
        {
            _currentSaveStage = _currentStage;
        }

        // 2. Item��ġ üũ �� ����
        if (!DataManager.Instance.SaveData.GameData.HasItem)
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
        switch (_currentSaveStage)
        {
            case (int)EStage.First:
                DataManager.Instance.SaveData.GameData.CameraPos = new Vector3(0, 9 , -4);
                break;
            case (int)EStage.Second:
                DataManager.Instance.SaveData.GameData.CameraPos = new Vector3(0, 63, -4);
                break;
            case (int)EStage.Third:
                DataManager.Instance.SaveData.GameData.CameraPos = new Vector3(0, 153, -4);
                break;
            case (int)EStage.Fourth:
                DataManager.Instance.SaveData.GameData.CameraPos = new Vector3(0, 243, -4);
                break;
        }

        DataManager.Instance.SaveData.GameData.IsClear = false;
        DataManager.Instance.SaveData.GameData.PlayerStage = _currentSaveStage;
        DataManager.Instance.SaveData.GameData.HasItem = false;
        DataManager.Instance.SaveData.GameData.ItemStage = _currentStage;
        DataManager.Instance.SaveData.GameData.PlayTime = _curPlayTime;

        DataManager.Instance.Save();

        Application.Quit();
    }

    private void GoToMain(PointerEventData eventData)
    {
        _sceneChanger.ChangeScene("MainScene");
    }


    public void Reset()
    {
        for (int i = 0; i < _resetObjects.Length; i++)
        {
            foreach (GameObject j in _resetObjects)
            {
                IResetObject resetObject = j.GetComponent<IResetObject>();
                resetObject.Reset();
            }
        }

    }

    // ���� ĳ���Ͱ� Base�� �ƴ� ���, Replace�� �ʿ��� Obstacle�� ��ü ����
    private void CheckReplaceObstacle()
    {
        if (DataManager.Instance.SaveData.GameData.CharacterNum == (int)ECharacterNum.Stone)
        {
            for (int i = 0; i < _replaceObstacles.Length; i++)
            {
                foreach (GameObject j in _replaceObstacles)
                {
                    IReplaceObstacle replaceObstacle = j.GetComponent<IReplaceObstacle>();
                    replaceObstacle.Replace();
                }
            }
        }
    }

    public void ClearStage()
    {
        Time.timeScale = 0;
        DataManager.Instance.ResetData();
        _clearPanel.SetActive(true);
        SoundManager.Instance.PlaySFX(_audioClear);
    }

    private void UpdateJumpTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.JumpTime);
        GetUI<TextMeshProUGUI>("JumpTime").SetText(_sb);
        GetUI<TextMeshProUGUI>("JumpTime2").SetText(_sb);
    }
    private void UpdateFallTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.FallTime);
        GetUI<TextMeshProUGUI>("FallTime").SetText(_sb);
        GetUI<TextMeshProUGUI>("FallTime2").SetText(_sb);
    }
    private void UpdatePlayTime()
    {
        _sb.Clear();
        TimeSpan timeSpan = TimeSpan.FromSeconds(_curPlayTime);
        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
        _sb.Append(formattedTime);
        GetUI<TextMeshProUGUI>("PlayTime").SetText(_sb);
        GetUI<TextMeshProUGUI>("PlayTime2").SetText(_sb);
    }

    void CheckPlayTime()
    {
        _curPlayTime += Time.deltaTime;
        DataManager.Instance.SaveData.GameData.PlayTime = _curPlayTime;
    }
}
