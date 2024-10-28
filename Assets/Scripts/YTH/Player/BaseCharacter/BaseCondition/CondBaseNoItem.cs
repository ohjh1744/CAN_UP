using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseNoItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        if (_data.HasItem == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
