using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class CsvParser : MonoBehaviour
{

    [SerializeField] private IObjectPosition[] _objectPositions;

    //юс╫ц©К
    private Vector3[] _positions = { new Vector3(1, 1, 0), new Vector3(1, 1, 2) };
    private string[] _names = { "OBstacle1", "Obstacle2" };

    private StringBuilder _sb = new StringBuilder();

    private void Awake()
    {
        Vector3toString();
    }
    
    private void Vector3toString()
    {
        for(int i = 0; i < _positions.Length; i++)
        {
            StringBuilder _tempSb = new StringBuilder();

            _tempSb.Append(_names[i]);
            _tempSb.Append(",");
            _tempSb.Append(_positions[i].x);
            _tempSb.Append(",");
            _tempSb.Append(_positions[i].y);
            _tempSb.Append(",");
            _tempSb.Append(_positions[i].z);

            //Debug.Log(_tempSb.ToString());

            _sb.AppendLine(string.Join(",", _tempSb));

            Debug.Log(_sb.ToString());
        }

       
        

 
    }


}
