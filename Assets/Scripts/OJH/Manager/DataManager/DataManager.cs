using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;

public enum EStage { First = 1, Second = 2, Third = 3, Fourth = 4, Fifth = 5, Length = 6 }

public enum ECharacterNum {Base = 1, Stone, Jump, Length }

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance { get { return _instance; } private set { } }

    [SerializeField] private SaveData _saveData;
    public SaveData SaveData { get { return _saveData; } private set { } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 포기하기 버튼 눌렀을때 Reset
    public void ResetData()
    {
        // PlayerStage 처음으로
        _saveData.GameData.PlayerStage = (int)EStage.First;

        // 아이템 보유 여부는 없음.
        _saveData.GameData.HasItem = false;

        //ItemStage도 처음의 SavePoint로
        _saveData.GameData.ItemStage = (int)EStage.First;

        //JumpTime 초기화
        _saveData.GameData.JumpTime = 0;

        //FallTime 초기화
        _saveData.GameData.FallTime = 0;

        //PlayTime 초기화
        _saveData.GameData.PlayTime = 0;
    }

    public void Save()
    {
        StringBuilder path = new StringBuilder();
        path.Append(Application.persistentDataPath).Append("/Save");
        if (Directory.Exists(path.ToString()) == false)
        {
            Directory.CreateDirectory(path.ToString());
        }

        string json = JsonUtility.ToJson(SaveData.GameData);
        File.WriteAllText($"{path}/SaveFile.txt", json);
    }

    public void Load(string loadName)
    {
        StringBuilder path = new StringBuilder();
        path.Append(Application.persistentDataPath).Append($"/Save/SaveFile.txt");
        if (File.Exists(path.ToString()) == false)
        {
            Debug.Log("Cant Find Save File");
            return;
        }
        string json = File.ReadAllText(path.ToString());
        SaveData.GameData = JsonUtility.FromJson<GameData>(json);
        Debug.Log("Comoplete");
        Debug.Log($"{Application.persistentDataPath}");

    }
}
