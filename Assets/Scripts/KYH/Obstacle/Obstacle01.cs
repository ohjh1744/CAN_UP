using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle01 : MonoBehaviour
{
    [SerializeField] BaseData _baseData;

    [SerializeField] PlayerData _playerData;

    [SerializeField] private bool _isIncrease;

    public void ForcedJump(PlayerController player)
    {
        if (_isIncrease == true)
            return;

        if (player.gameObject.tag == "Base")
        {
            _baseData = player.GetComponent<BaseData>();
            _baseData.MaxJumpPower *= 2;
            _isIncrease = true;
        }
        else
        {
            _playerData = player.GetComponent<PlayerData>();
            _playerData.JumpPower *= 2;
            _isIncrease = true;
        }
    }

    public void CancelJump(PlayerController player)
    {
        if (_isIncrease == false)
            return;

        if (player.gameObject.tag == "Base")
        {
            _baseData = player.GetComponent<BaseData>();
            _baseData.MaxJumpPower /= 2;
            _isIncrease = false;
        }
        else
        {
            _playerData = player.GetComponent<PlayerData>();
            _playerData.JumpPower /= 2;
            _isIncrease = false;
        }
    }
}
