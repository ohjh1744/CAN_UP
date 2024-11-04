using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private int _index;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameSceneManager _gameSceneManager;

    [SerializeField] private int _cameraHeight;

    [SerializeField] private int _cameraOffsetZ;

    private int _cameraHalfHeight;

    private void OnTriggerStay(Collider other)
    {
        _cameraHalfHeight = _cameraHeight / 2;

        if (other.gameObject.tag == "Base" || other.gameObject.tag == "Stone" || other.gameObject.tag == "Jumper")
        {
            Debug.Log("hi");
            Rigidbody rigid = _gameSceneManager.Players[(int)DataManager.Instance.SaveData.GameData.CharacterNum].GetComponent<Rigidbody>();
            if (rigid.velocity.y < 0)
            {
                _camera.transform.position = new Vector3(0, (_cameraHeight * _index) - _cameraHalfHeight, _cameraOffsetZ);
                Debug.Log("hello");
            }
            else if (rigid.velocity.y > 0)
            {
                _camera.transform.position = new Vector3(0, (_cameraHeight * _index) - _cameraHalfHeight + _cameraHeight, _cameraOffsetZ);
                Debug.Log("hiiii");
            }
        }
    }

}