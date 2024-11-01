using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActStoneMove : PlayerAction
{
    [SerializeField] StoneData _data;


    public override BTNodeState DoAction()
    {
        Debug.Log("날아가는 로직 진입함");
        ApplyForceToPlayer();
        Debug.Log("힘 줌");
        return BTNodeState.Success;
    }

    private void ApplyForceToPlayer()
    {
        // 선택된 플레이어가 없으면 return
        if (_data.SelectedPlayer == null) return;

        Vector3 releasePosition = _data.MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _data.MainCamera.WorldToScreenPoint(_data.SelectedPlayer.transform.position).z));
        releasePosition.z = _data.SelectedPlayer.transform.position.z;

        // 방향 벡터
        float dragDistance = Vector3.Distance(_data.DragStartPoint, releasePosition);

        if (dragDistance > _data.MaxPullDistance)
        {
            dragDistance = _data.MaxPullDistance;
            releasePosition = _data.DragStartPoint + (releasePosition - _data.DragStartPoint).normalized;
        }
        if (dragDistance >= 1f && dragDistance <= _data.MaxPullDistance * (1/3))
        {
            _data.JumpPower *= 1 / 3; 
        }
        else if (dragDistance > _data.MaxPullDistance * (1 / 3) && dragDistance <= _data.MaxPullDistance * (2 / 3))
        {
            _data.JumpPower *= 2 / 3;
        }
        else if (dragDistance > _data.MaxPullDistance * (2 / 3) && dragDistance <= _data.MaxPullDistance)
        {
            _data.JumpPower *= 1;
        }

        Vector3 forceDirection = (_data.DragStartPoint - releasePosition).normalized;

        // 캐릭터의 위치와 마우스커서 위치의 거리를 float값으로 저장
        float forceMagnitude = dragDistance * _data.JumpPower;

        Rigidbody rb = _data.SelectedPlayer.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 힘을 가해주는 위치 설정
            rb.AddForceAtPosition(forceDirection * forceMagnitude, _data.SelectedPlayer.transform.position, ForceMode.Impulse);

            //_data.Flying = true;
            StartCoroutine(Delay());
        }
        _data.SelectedPlayer = null;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        _data.Animator.SetBool("Flying", true);
        _data.IsGrounded = false;

    }
}
