using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UiCommonSound : UIBInder
{

    [SerializeField] private AudioClip _audioClip;

    public AudioClip AudioClip { get { return _audioClip; } private set { } }

    public void PlayCommonSound(PointerEventData eventData)
    {
        Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        SoundManager.Instance.PlaySFX(_audioClip);
    }
}
