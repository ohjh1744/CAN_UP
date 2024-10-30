using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseHasItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        if (_data.HasItem == true)
        {
            Debug.Log("아이템 사용 가능 + 아이템 소지 확인");
            return true;
        }
        else
        {
            Debug.Log("아이템 사용 가능 + 아이템 소지 X");
            return false;
        }
    }
}
