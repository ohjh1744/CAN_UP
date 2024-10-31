using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class CsvParser : MonoBehaviour
{

    [SerializeField] private IObjectPosition[] _objectPositions;

    //임시용
    //private Vector3[] _positions = { new Vector3(1, 1, 0), new Vector3(1, 1, 2) };
    //private string[] _names = { "OBstacle1", "Obstacle2" };

    private StringBuilder _sb = new StringBuilder();

    private string _savePath;

    private void Awake()
    {
        // 저장경로 user/appdata/LocalLow/Can_Up/Save
        _savePath = Application.persistentDataPath + "/Save";
        CreateCsv();
    }

    [ContextMenu("Save")]
    private void CreateCsv()
    {
        
        //csv형식으로 stringbuilder에 저장.
        for(int i = 0; i < _objectPositions.Length; i++)
        {
            StringBuilder _tempSb = new StringBuilder();

            _tempSb.Append(_objectPositions[i].Name);
            _tempSb.Append(",");
            _tempSb.Append(_objectPositions[i].Position.x);
            _tempSb.Append(",");
            _tempSb.Append(_objectPositions[i].Position.y);
            _tempSb.Append(",");
            _tempSb.Append(_objectPositions[i].Position.z);
            _tempSb.Append("\n");

            _sb.Append(_tempSb);
        }

        // 저장경로가 존재하지않다면 생성. 있다면 기존꺼 사용.
        if(Directory.Exists(_savePath) == false)
        {
            Directory.CreateDirectory(_savePath);
        }

        // WRite 작성.
        File.WriteAllText(_savePath + "/Save.csv", string.Join("\n", _sb));





    }


}
