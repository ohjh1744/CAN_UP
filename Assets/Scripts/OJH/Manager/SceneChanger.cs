using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mainUI;

    [SerializeField] private float _loadingTime;

    private Coroutine _loadingRoutine;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        _mainUI.SetActive(false);
        if (_loadingRoutine != null)
        {
            return;
        }
        _loadingRoutine = StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        oper.allowSceneActivation = false;

        while (oper.isDone == false)
        {
            if (oper.progress < 0.9f)
            {
                Debug.Log($"loading = {oper.progress}");
            }
            else
            {

                break;
            }
            yield return null;
        }


        //Fake Loading
        float time = 0f;
        while (time < _loadingTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        Debug.Log("loading Success");
        oper.allowSceneActivation = true;
    }

}
