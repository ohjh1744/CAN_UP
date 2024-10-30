using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoneData : PlayerData
{
    [SerializeField] private Vector3 _clickDownPos;

    public Vector3 ClickDownPos { get { return _clickDownPos; } set { _clickDownPos = value; } }


    [SerializeField] private Vector3 _clickUpPos;

    public Vector3 ClickUpPos { get { return _clickUpPos; } set { _clickUpPos = value; } }

    [SerializeField] private float _rayDistance;

    public float RayDistance { get { return _rayDistance; } set { _rayDistance = value; } }
    // 메인 카메라
    [SerializeField] Camera _mainCamera;

    public Camera MainCamera { get { return _mainCamera; } set { _mainCamera = value; } }

    // 라인 렌더러
    [SerializeField] LineRenderer _lineRenderer;

    public LineRenderer LineRenderer { get { return _lineRenderer; } set { _lineRenderer = value; } }

    // 선택된 플레이어
    [SerializeField] GameObject _selectedPlayer;

    public GameObject SelectedPlayer { get { return _selectedPlayer; } set { _selectedPlayer = value; } }

    // 현재 드래그를 진행중인지
    [SerializeField] bool _isDragging = false;

    public bool IsDragging {  get { return _isDragging; } set { _isDragging = value; } }

    // 드래그를 시작한 위치
    [SerializeField] Vector3 _dragStartPoint;

    public Vector3 DragStartPoint { get { return _dragStartPoint; } set { _dragStartPoint = value; } }

    //// 날리는 힘
    //[SerializeField] float _forceValue;
    //public float ForceValue { get { return _forceValue; } set { _forceValue = value; } }
    
    // 에니메이터
    [SerializeField] Animator _animator;

    public Animator Animator { get { return _animator; } set { _animator = value; } }

    // 당기는 최대거리
    [SerializeField] float _maxPullDistance;
    public float MaxPullDistance { get { return _maxPullDistance; } set { _maxPullDistance = value; } }

    [SerializeField] bool _flying = false;

    public bool Flying { get { return _flying; } set { _flying = value; } }

    [SerializeField] bool _standAni = false;

    public bool StandAni { get { return _standAni; } set { _standAni = value; } }


}
