using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle01 : MonoBehaviour
{
    [SerializeField] private PlayerData _data;
    
    public void ForcedJump(PlayerController player)
    {
        _data.JumpPower *= 2;
    }
}
