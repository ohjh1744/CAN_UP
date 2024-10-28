using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseCanUseItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        if (_data.IsStiff == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
