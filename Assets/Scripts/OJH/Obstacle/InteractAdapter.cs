using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player와 상호작용할 기믹 인스펙터창에 adapter 붙인후 인스펙터창에서 event에다가 함수 연결.
public class InteractAdapter : MonoBehaviour, IInteractable
{
    // 이벤트를 이용한 어뎁터 방식
    public UnityEvent<PlayerController> OnInteractPlayerColEnter;

    public UnityEvent<PlayerController> OnInteractPlayerColStay;

    public UnityEvent<PlayerController> OnInteractPlayerColExit;

    public UnityEvent<PlayerController> OnInteractPlayerTriEnter;

    public UnityEvent<PlayerController> OnInteractPlayerTriStay;

    public UnityEvent<PlayerController> OnInteractPlayerTriExit;

    //아이템
    public UnityEvent<Item> OnInteractItemColEnter;

    public UnityEvent<Item> OnInteractItemColStay;

    public UnityEvent<Item> OnInteractItemColExit;

    public UnityEvent<Item> OnInteractItemTriEnter;

    public UnityEvent<Item> OnInteractItemTriStay;

    public UnityEvent<Item> OnInteractItemTriExit;

    public void TargetInteractColEnter(PlayerController player)
    {
        OnInteractPlayerColEnter?.Invoke(player);
    }

    public void TargetInteractColStay(PlayerController player)
    {
        OnInteractPlayerColStay?.Invoke(player);
    }

    public void TargetInteractColExit(PlayerController player)
    {
        OnInteractPlayerColExit?.Invoke(player);
    }

    public void TargetInteractTriEnter(PlayerController player)
    {
        OnInteractPlayerTriEnter?.Invoke(player);
    }

    public void TargetInteractTriStay(PlayerController player)
    {
        OnInteractPlayerTriStay?.Invoke(player);
    }

    public void TargetInteractTriExit(PlayerController player)
    {
        OnInteractPlayerTriExit?.Invoke(player);
    }

    //아이템
    public void TargetInteractColEnter(Item item)
    {
        OnInteractItemColEnter?.Invoke(item);
    }

    public void TargetInteractColStay(Item item)
    {
        OnInteractItemColStay?.Invoke(item);
    }

    public void TargetInteractColExit(Item item)
    {
        OnInteractItemColExit?.Invoke(item);
    }

    public void TargetInteractTriEnter(Item item)
    {
        OnInteractItemTriEnter?.Invoke(item);
    }

    public void TargetInteractTriStay(Item item)
    {
        OnInteractItemTriStay?.Invoke(item);
    }

    public void TargetInteractTriExit(Item item)
    {
        OnInteractItemTriExit?.Invoke(item);
    }
}