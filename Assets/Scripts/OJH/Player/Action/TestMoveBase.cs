using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveBase : PlayerAction
{
    [SerializeField] private float power;
    public override BTNodeState DoAction()
    {
        Debug.Log("¿òÁ÷ÀÓ!");
        power += Time.deltaTime;
        return BTNodeState.Running;
    }

}
