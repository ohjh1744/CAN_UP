using UnityEngine;

public class ActStoneReadyMove : PlayerAction
{
    [SerializeField] StoneData _data;
    [SerializeField] StoneRagdoll _ragdoll;

    public override BTNodeState DoAction()
    {
        if (Input.GetMouseButton(0))
        {
            DetectPlayerWithRay();
            _data.Flying = false;

            if (_data.IsDragging)
            {
                DrawLineToCursor();
            }
            return BTNodeState.Running;
        }
        
        else if(Input.GetMouseButtonUp(0)) 
        {
            _data.IsDragging = false;
            _data.LineRenderer.enabled = false;

            //_ragdoll.AddForceRagdoll(Vector3.up * 5);
            _ragdoll.RagDollOn();
            //ApplyForceToPlayer();
            Debug.Log("레그돌 시작");
            return BTNodeState.Failure;
        }
        return BTNodeState.Running;

    }

    private void DetectPlayerWithRay()
    {
        //Debug.Log("마우스 왼쪽 버튼 누름");
        // 카메라가 비추는 화면에서 스크린에 레이를 발사하는 로직
        Ray ray = _data.MainCamera.ScreenPointToRay(Input.mousePosition);

        // 레이케스트를 사용해서 ray변수에 닿은 물체가 있고, 해당 물체의 태그가 Player인 경우
        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit) && hit.collider.CompareTag("Player"))
        {
            // 감지된 오브젝트를 선언해둔 selectedPlayer에 저장
            _data.SelectedPlayer = hit.collider.gameObject;

            // 현재 드래그중
            _data.IsDragging = true;

            // 드래그 시작 위치를 감지된 플레이어의 위치로 저장
            _data.DragStartPoint = _data.SelectedPlayer.transform.position;

            // 라인 렌더러는 활성화
            _data.LineRenderer.enabled = true;

        }
    }

    // 라인 렌더러를 활용한 선을 그리는 함수
    void DrawLineToCursor()
    {

        Vector3 mousePosition = _data.MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _data.MainCamera.WorldToScreenPoint(_data.SelectedPlayer.transform.position).z));
        mousePosition.z = _data.SelectedPlayer.transform.position.z;

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
