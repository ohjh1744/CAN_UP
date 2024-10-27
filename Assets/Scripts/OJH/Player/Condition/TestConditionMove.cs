using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConditionMove : PlayerCondition
{
    public override bool DoCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("스페이스바 누르는 중");
            return true;
        }
        else
        {
            Debug.Log("스페이스바 안누름");
            return false;
        }
    }
}
