using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoneData : PlayerData
{
    private Vector3 _clickDownPos;

    public Vector3 ClickDownPos { get { return _clickDownPos; } set { _clickDownPos = value; } }


    private Vector3 _clickUpPos;

    public Vector3 ClickUpPos { get { return _clickUpPos; } set { _clickUpPos = value; } }
}
