using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameData
{
    // Player가 Normal Level을 깼는지, 깻다면 캐릭터 해방을 위한 변수.
    [SerializeField] private bool _isClear;

    public bool IsClear { get {return _isClear;} set { _isClear = value; } }

    [SerializeField] private int _characterNum;

    public int CharacterNum { get { return _characterNum; } set { _characterNum = value; } }

    //현재 플레이어가 위치한 Stage
    [SerializeField] private int _playerStage;

    public int PlayerStage {  get { return _playerStage; } set { _playerStage = value; } }

    //아이템을 소유하고 있는지
    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } }

    //아이템이 어느 스테이지에 존재하고있는지
    // 만약 소유하고있지 않는상태에서, PlayerStage와 ItemStage가 다르다면 아이템 위치는 PlayerStage의 SavePOint로 이동
    // 소유하고 있는 상태면 Player위치와 동일.
    [SerializeField] private int _itemStage;

    public int ItemStage { get { return _itemStage; } set { _itemStage = value; } }

    //점프 횟수 mvp 패턴 적용
    [SerializeField] private int _jumpTime;

    public int JumpTime {  get { return _jumpTime; } set { _jumpTime = value; OnJumpTimeChange?.Invoke(); } }

    //떨어진 횟수 mvp 패턴 적용
    [SerializeField] private int _fallTime;

    public int FallTime { get { return _fallTime; } set { _fallTime = value; OnFallTimeChange?.Invoke(); } }

    //플레이 시간 ex) 00:00:00  mvp 패턴 적용
    [SerializeField] private float _playTime;

    public float PlayTime { get { return _playTime; } set { _playTime = value; OnPlayTimeChange?.Invoke(); } }

    public event UnityAction OnJumpTimeChange;

    public event UnityAction OnFallTimeChange;

    public event UnityAction OnPlayTimeChange;
}

[CreateAssetMenu(menuName = "ScriptableObjects/SaveData")]
public class SaveData : ScriptableObject
{
    [SerializeField] private GameData _gameData;
    public GameData GameData { get { return _gameData; } set { _gameData = value; } }
}