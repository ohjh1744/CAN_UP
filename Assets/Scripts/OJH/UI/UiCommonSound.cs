using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiCommonSound : UIBInder
{

    [SerializeField] private AudioClip _audioClip;


    private void Awake()
    {
        BindAll();
    }

    private void Start()
    {
        AddEvent("NewPlayButton", EventType.Click, PlayCommonSound);
        AddEvent("DifficultyUp", EventType.Click, PlayCommonSound);
        AddEvent("DifficultyDown", EventType.Click, PlayCommonSound);
        AddEvent("Character_Right", EventType.Click, PlayCommonSound);
        AddEvent("Character_Left", EventType.Click, PlayCommonSound);
        AddEvent("Character_Left", EventType.Click, PlayCommonSound);
        AddEvent("LoadPlayButton", EventType.Click, PlayCommonSound);
        AddEvent("ExplainButton", EventType.Click, PlayCommonSound);
        AddEvent("ExitButton", EventType.Click, PlayCommonSound);
    }

    private void PlayCommonSound(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySFX(_audioClip);
    }
}
