using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseCanUseItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        Debug.Log("Can use Item");
        if (_data.IsStiff == true)
        {
            Debug.Log("아이템 사용 불가능");
            return false;
        }
        else
        {
            return true;
        }

    }
}
