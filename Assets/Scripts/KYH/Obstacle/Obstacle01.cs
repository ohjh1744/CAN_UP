using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle01 : MonoBehaviour
{
    [SerializeField] PlayerData _data;

    public void AddJumpForce(PlayerController player)
    {
        // 테스트할 때 진행해볼 것

        // 플레이어 오브젝트가 null이거나 플레이어가 StoneCharacter인 경우 예외처리
        if (player == null || player.gameObject.name == "StoneCharacter")
            return;

        // OnTriggerStay 동안 JumpPower를 2배 증가
        _data.JumpPower *= 2;
    }
}
