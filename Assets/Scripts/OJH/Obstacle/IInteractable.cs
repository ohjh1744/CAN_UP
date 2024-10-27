using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void TargetInteractEnter(PlayerController player);
    void TargetInteractStay(PlayerController player);
    void TargetInteractExit(PlayerController player);
}
