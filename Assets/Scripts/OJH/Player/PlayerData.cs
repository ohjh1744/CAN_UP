using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _jumpNum;

    public int JumpNum { get {return _jumpNum; } set { _jumpNum = value; } }
    
    [SerializeField] private int _fallNum;

    public int FallNum { get { return _fallNum; } set { _fallNum = value; } }


}
