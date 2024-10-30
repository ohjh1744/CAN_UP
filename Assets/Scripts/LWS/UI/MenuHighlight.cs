using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _arrowIcon;
        
    public void OnPointerEnter(PointerEventData eventData)
    {
        _arrowIcon.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _arrowIcon.SetActive(false);
    }
}
