using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //collision
    // Player와 접촉시 발생하는 함수
    void TargetInteractColEnter(PlayerController player);

    // Player와 접촉중에 발생하는 함수
    void TargetInteractColStay(PlayerController player);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractColExit(PlayerController player);

    //trigger
    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriEnter(PlayerController player);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriStay(PlayerController player);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriExit(PlayerController player);

    // Item과의 상호작용 함수들
    void TargetInteractColEnter(Item item);

    void TargetInteractColStay(Item item);

    void TargetInteractColExit(Item item);

    void TargetInteractTriEnter(Item item);

    void TargetInteractTriStay(Item item);

    void TargetInteractTriExit(Item item);

}
