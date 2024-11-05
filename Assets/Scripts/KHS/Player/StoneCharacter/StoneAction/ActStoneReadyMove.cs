using UnityEngine;


public enum EStoneSound {Pull, Fly }
public class ActStoneReadyMove : PlayerAction
{
    [SerializeField] StoneData _data;
    //[SerializeField] StoneRagdoll _ragdoll;
    [SerializeField] GameObject _playerForcePos;

    [SerializeField] AudioSource _audio;

    [SerializeField] AudioClip[] _audioClip;

    public override BTNodeState DoAction()
    {
        if (Input.GetMouseButton(0))
        {
            DetectPlayerWithRay();
            if (_data.IsDragging)
            {
                Debug.Log("땅김");
                DrawLineToCursor();
            }
        }
        
        if(Input.GetMouseButtonUp(0) && _data.SelectedPlayer != null) 
        {
            Debug.Log("마우스 땜");
            _audio.loop = false;
            _audio.PlayOneShot(_audioClip[(int)EStoneSound.Fly]);
            _data.IsDragging = false;
            _data.LineRenderer.enabled = false;
            return BTNodeState.Success;
        }

        return BTNodeState.Failure;

    }

    private void DetectPlayerWithRay()
    {
        //Debug.Log("마우스 왼쪽 버튼 누름");
        // 카메라가 비추는 화면에서 스크린에 레이를 발사하는 로직
        Ray ray = _data.MainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if(hit.collider.CompareTag("Stone"))
            {
                // 사운드 처리
                _audio.clip = _audioClip[(int)EStoneSound.Pull];
                _audio.loop = true;
                if (_audio.isPlaying == false)
                {
                    _audio.Play();
                }
                // 감지된 오브젝트를 선언해둔 selectedPlayer에 저장
                _data.SelectedPlayer = hit.collider.gameObject;

                // 현재 드래그중
                _data.IsDragging = true;

                // 드래그 시작 위치를 감지된 플레이어의 위치로 저장
                _data.DragStartPoint = _playerForcePos.transform.position; /*_data.SelectedPlayer.transform.position;*/

                // 라인 렌더러는 활성화
                _data.LineRenderer.enabled = true;

                Debug.Log("스톤 캐릭터 감지");
            }
            Debug.Log("Hit: " + hit.collider.name);
            // 필요한 경우 추가 처리 가능
        }
    }

    // 라인 렌더러를 활용한 선을 그리는 함수
    void DrawLineToCursor()
    {

        Vector3 mousePosition = _data.MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _data.MainCamera.WorldToScreenPoint(_playerForcePos.transform.position/*_data.SelectedPlayer.transform.position*/).z));
        mousePosition.z = _playerForcePos.transform.position.z; /*_data.SelectedPlayer.transform.position.z;*/

        float dragDistance = Vector3.Distance(_data.DragStartPoint, mousePosition);

        if (dragDistance > _data.MaxPullDistance)
        {
            Vector3 limitedPosition = _data.DragStartPoint + (mousePosition - _data.DragStartPoint).normalized * _data.MaxPullDistance;
            _data.LineRenderer.SetPosition(0, _data.DragStartPoint);
            _data.LineRenderer.SetPosition(1, limitedPosition);

            //Debug.Log("커서 최대거리 넘어감");
        }
        else
        {
            _data.LineRenderer.SetPosition(0, _data.DragStartPoint);
            _data.LineRenderer.SetPosition(1, mousePosition);

            //Debug.Log("커서 작동중");
        }
    }




}
