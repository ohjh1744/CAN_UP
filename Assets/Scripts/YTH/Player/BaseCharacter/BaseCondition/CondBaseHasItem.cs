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
            return true;
        }
        else
        {
            return false;
        }
    }
}
