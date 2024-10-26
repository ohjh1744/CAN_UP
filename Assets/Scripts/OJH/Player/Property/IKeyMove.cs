using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKeyMove
{
    public float MoveSpeed { get; set; }

    public Vector3 MoveDir { get; set; }
}
