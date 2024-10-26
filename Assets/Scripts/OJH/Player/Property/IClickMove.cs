using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickMove
{
    public Vector3 ClickDownPos { get; set; }

    public Vector3 ClickUpPos { get; set; }
}
