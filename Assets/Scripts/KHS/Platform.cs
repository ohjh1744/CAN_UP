using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameSceneManager _gameSceneManager;
    [SerializeField] EStage _stage;
    [SerializeField] bool _isSavePlatform;

    private void OnCollisionEnter(Collision collision)
    {
        // 플렛폼이 플레이어를 감지하였을때
        if (collision.collider.CompareTag("Base") || collision.collider.CompareTag("Stone") || collision.collider.CompareTag("Jumper"))
        {
            // 세이브하는 플렛폼일 경우
            if (_isSavePlatform == true)
            {
                //UpdateSavePoint(_stage);
            }
        }
    }

    // 세이브 포인트 지점 설정
    //private void UpdateSavePoint(EStage stage)
    //{
    //    switch (stage)
    //    {
    //        // 1번째 세이브지점
    //        case EStage.First:
    //            _gameSceneManager._savePoints[1] = transform.position;
    //            _gameSceneManager._currentSaveStage = 1;
    //            break;

    //        // 2번째 세이브지점
    //        case EStage.Second:
    //            _gameSceneManager._savePoints[2] = transform.position;
    //            _gameSceneManager._currentSaveStage = 2;
    //            break;

    //        // 3번째 세이브지점
    //        case EStage.Third:
    //            _gameSceneManager._savePoints[3] = transform.position;
    //            _gameSceneManager._currentSaveStage = 3;
    //            break;

    //        // 4번째 세이브지점
    //        case EStage.Fourth:
    //            _gameSceneManager._savePoints[4] = transform.position;
    //            _gameSceneManager._currentSaveStage = 4;
    //            break;

    //        // 5번째 세이브지점
    //        case EStage.Fifth:
    //            _gameSceneManager._savePoints[5] = transform.position;
    //            _gameSceneManager._currentSaveStage = 5;
    //            break;
    //    }

    //}

}
