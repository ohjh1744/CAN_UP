using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour , IObjectPosition
{
    [SerializeField] GameSceneContext _gameSceneManager;

    [SerializeField] EStage _stage;

    [SerializeField] bool _isSavePlatform;

    [SerializeField] bool _isClearPlatform;

    [SerializeField] string _name;

    [SerializeField] AudioSource _audio;

    [SerializeField] AudioClip _audioClip;

    public string Name { get { return _name; } set { _name = value; } }
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    private void Awake()
    {
        _audio = gameObject.AddComponent<AudioSource>();
        _audioClip = Resources.Load<AudioClip>("AudioClip/bump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플렛폼이 플레이어를 감지하였을때
        if (collision.collider.CompareTag("Base") || collision.collider.CompareTag("Stone") || collision.collider.CompareTag("Jumper"))
        {
            if(collision.collider.CompareTag("Base") || collision.collider.CompareTag("Stone"))
            {
                _audio.PlayOneShot(_audioClip);
                UpdateSavePoint(_stage);
            }


            if(_isClearPlatform == true)
            {
                DataManager.Instance.SaveData.GameData.IsClear = true;
                _gameSceneManager.ClearStage();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigid = collision.collider.GetComponent<Rigidbody>();
        if (rigid.velocity.y <= 0)
        {
            rigid.velocity = Vector3.down;
        }
    }

    // 세이브 포인트 지점 및 현재 currentStage 설정.
    private void UpdateSavePoint(EStage stage)
    {
        Debug.Log(true);
        switch (stage)
        {
            // 1번째 세이브지점
            case EStage.First:
                _gameSceneManager.CurrentStage = 1;
                if(_isSavePlatform == true)
                {
                    _gameSceneManager.CurrentSaveStage = 1;
                }
                break;

            // 2번째 세이브지점
            case EStage.Second:
                _gameSceneManager.CurrentStage = 2;
                if (_isSavePlatform == true)
                {
                    _gameSceneManager.CurrentSaveStage = 2;
                }
                break;

            // 3번째 세이브지점
            case EStage.Third:
                _gameSceneManager.CurrentStage = 3;
                if (_isSavePlatform == true)
                {
                    _gameSceneManager.CurrentSaveStage = 3;
                }
                break;

            // 4번째 세이브지점
            case EStage.Fourth:
                _gameSceneManager.CurrentStage = 4;
                if (_isSavePlatform == true)
                {
                    _gameSceneManager.CurrentSaveStage = 4;
                }
                break;

            // 5번째 세이브지점
            case EStage.Fifth:
                _gameSceneManager.CurrentStage = 5;
                if (_isSavePlatform == true)
                {
                    _gameSceneManager.CurrentSaveStage = 5;
                }
                break;
        }

    }

}
