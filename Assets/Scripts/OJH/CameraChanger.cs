using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private int _index;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameSceneManager _gameSceneManager;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Base" || other.gameObject.tag == "Stone" || other.gameObject.tag == "Jumper")
        {
            Debug.Log("hi");
            Rigidbody rigid = _gameSceneManager.Players[(int)DataManager.Instance.SaveData.GameData.CharacterNum].GetComponent<Rigidbody>();
            if (rigid.velocity.y < 0)
            {
                _camera.transform.position = new Vector3(0, (18 * _index) - 9, -4);
                Debug.Log("hello");
            }
            else if (rigid.velocity.y > 0)
            {
                _camera.transform.position = new Vector3(0, (18 * _index) - 9 + 18, -4);
                Debug.Log("hiiii");
            }
        }
    }

}