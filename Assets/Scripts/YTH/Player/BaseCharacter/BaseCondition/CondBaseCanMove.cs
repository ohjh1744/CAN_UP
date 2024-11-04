using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Vector3 _size;

    public override bool DoCheck()
    {
        Vector3 _curPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // OverlapBox를 띄울 현재 위치 좌표

        Collider[] _hit = Physics.OverlapBox(_curPos, _size, Quaternion.identity); // 발 끝에 육면체를 만들어 
                                                                              // 충돌체를 배열로 받음
        for (int i = 0; i < _hit.Length; ++i)  
        {
            if (_hit[i].CompareTag("Ground") || _hit[i].CompareTag("ObstacleTri") || _hit[i].CompareTag("ObstacleCol"))
            {
                _data.IsGrounded = true;
                return true;
            }
            else
            {
                _data.IsGrounded = false;
            }
        }

        if (_data.IsStiff == true || _data.IsGrounded == false) // 물리적으로 밀쳐진 상태, 땅에 있는 상태가 아닐 때 => 이동 불가
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnDrawGizmos() // OverlapBox의 기즈모를 게임씬에서 확인 가능
    {
        Vector3 gizmos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Gizmos.DrawWireCube( gizmos,  _size);
    }
}
