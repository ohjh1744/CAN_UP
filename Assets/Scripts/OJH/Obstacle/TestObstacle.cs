using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObstacle : MonoBehaviour
{
    // 기획서 및 피그마 보고 순서대로 인스펙터창에 보이도록 변수 구현.
    public void TouchPlayer(PlayerController player)
    {
        Transform playerTransform = player.GetComponent<Transform>();
        Debug.Log(playerTransform.position);
    }
}
