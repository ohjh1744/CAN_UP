using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player와 상호작용할 기믹 인스펙터창에 adapter 붙인후 인스펙터창에서 event에다가 함수 연결.
public class InteractAdapter : MonoBehaviour, IInteractable
{
    // 이벤트를 이용한 어뎁터 방식
    public UnityEvent<PlayerController> OnInteractEnter;

    public UnityEvent<PlayerController> OnInteractStay;

    public UnityEvent<PlayerController> OnInteractExit;

    public void TargetInteractEnter(PlayerController player)
    {
        OnInteractEnter?.Invoke(player);
    }

    public void TargetInteractStay(PlayerController player)
    {
        OnInteractStay?.Invoke(player);
    }

    public void TargetInteractExit(PlayerController player)
    {
        OnInteractExit?.Invoke(player);
    }

}