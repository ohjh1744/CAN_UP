using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;

    [SerializeField] private DataManager _dataManager;

    [SerializeField] private GameObject _explainImage;

    private void Start()
    {
        _explainImage.SetActive(false);
    }

    public void NewGameStart()
    {
        _dataManager.ResetData();
        _sceneChanger.ChangeScene("GameScene");
    }

    public void LastGameStart()
    {
        _sceneChanger.ChangeScene("GameScene");
    }

    public void ShowHowToPlay()
    {
        _explainImage.SetActive(true);
    }

    public void NextCharacter()
    {

    }

    public void NextDifficulty()
    {

    }

    public void QuitGame()
    {
        _sceneChanger.QuitGame();
    }
}
