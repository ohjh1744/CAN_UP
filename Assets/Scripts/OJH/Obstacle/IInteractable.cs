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

    void TargetInteractColEnter(Item item);

    // Player와 접촉중에 발생하는 함수
    void TargetInteractColStay(Item item);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractColExit(Item item);

    //trigger
    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriEnter(Item item);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriStay(Item item);

    // Player와 접촉 후 떨어졌을 때 발생하는 함수
    void TargetInteractTriExit(Item item);

}
