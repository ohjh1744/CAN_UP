using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    // Player와 접촉시 발생하는 함수
    void TargetInteractEnter(PlayerController player);

    // Player와 접촉중에 발생하는 함수
    void TargetInteractStay(PlayerController player);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractExit(PlayerController player);
}
