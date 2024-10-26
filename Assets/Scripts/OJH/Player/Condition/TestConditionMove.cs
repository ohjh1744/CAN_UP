using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConditionMove : PlayerCondition
{
    [SerializeField]private float power;
    public override bool DoCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            power += Time.deltaTime;
            Debug.Log("스페이스바 누르는 중");
            return true;
        }
        else
        {
            power = 0;
            Debug.Log("스페이스바 안누름");
            return false;
        }
    }
}
