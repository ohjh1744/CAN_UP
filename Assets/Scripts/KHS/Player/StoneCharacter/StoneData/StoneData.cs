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
    // 선택된 플레이어
    [SerializeField] GameObject _selectedPlayer;
    // 현재 드래그를 진행중인지
    [SerializeField] bool _isDragging = false;
    // 드래그를 시작한 위치
    [SerializeField] Vector3 _dragStartPoint;
    // 라인 렌더러
    [SerializeField] LineRenderer _lineRenderer;
    // 날리는 힘
    [SerializeField] float _forceValue;
    // 당기는 최대거리
    [SerializeField] float _maxPullDistance;
}
