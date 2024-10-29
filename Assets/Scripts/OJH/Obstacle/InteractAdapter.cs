using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player와 상호작용할 기믹 인스펙터창에 adapter 붙인후 인스펙터창에서 event에다가 함수 연결.
public class InteractAdapter : MonoBehaviour, IInteractable
{
    // 이벤트를 이용한 어뎁터 방식
    public UnityEvent<PlayerController> OnInteractColEnter;

    public UnityEvent<PlayerController> OnInteractColStay;

    public UnityEvent<PlayerController> OnInteractColExit;

    public UnityEvent<PlayerController> OnInteractTriEnter;

    public UnityEvent<PlayerController> OnInteractTriStay;

    public UnityEvent<PlayerController> OnInteractTriExit;

    public void TargetInteractColEnter(PlayerController player)
    {
        OnInteractColEnter?.Invoke(player);
    }

    public void TargetInteractColStay(PlayerController player)
    {
        OnInteractColStay?.Invoke(player);
    }

    public void TargetInteractColExit(PlayerController player)
    {
        OnInteractColExit?.Invoke(player);
    }

    public void TargetInteractTriEnter(PlayerController player)
    {
        OnInteractTriEnter?.Invoke(player);
    }

    public void TargetInteractTriStay(PlayerController player)
    {
        OnInteractTriStay?.Invoke(player);
    }

    public void TargetInteractTriExit(PlayerController player)
    {
        OnInteractTriExit?.Invoke(player);
    }

}