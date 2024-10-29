using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance { get { return _instance; } private set { } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Save()
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

    public void Load()
    {
        StringBuilder path = new StringBuilder();
        path.Append(Application.persistentDataPath).Append($"/Save/SaveFile.txt");
        if (File.Exists(path.ToString()) == false)
        {
            Reset();
            Debug.Log("Cant Find Save File");
            return;
        }
        string json = File.ReadAllText(path.ToString());
        SaveData.GameData = JsonUtility.FromJson<GameData>(json);
        Debug.Log("Comoplete");
        Debug.Log($"{Application.persistentDataPath}");

    }

}
