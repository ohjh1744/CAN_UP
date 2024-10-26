using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAction : MonoBehaviour
{
    public abstract BTNodeState DoAction();
}
