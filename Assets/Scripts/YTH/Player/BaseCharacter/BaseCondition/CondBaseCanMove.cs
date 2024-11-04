using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] float _dropRayPosY;

    [SerializeField] Vector3 _size;

    private RaycastHit hit;
    public override bool DoCheck()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _dropRayPosY, transform.position.z);

        Collider[] hit = Physics.OverlapBox(pos, _size, Quaternion.identity);

        for (int i = 0; i < hit.Length; ++i)
        {
            if (hit[i].CompareTag("Ground") || hit[i].CompareTag("ObstacleTri") || hit[i].CompareTag("ObstacleCol"))
            {
                _data.IsGrounded = true;
                return true;
            }
            else
            {
                _data.IsGrounded = false;
            }
        }



       // //Ray ray = new Ray(pos, Vector3.down);
       //
       // if (Physics.BoxCast(pos, transform.lossyScale / 4.0f, Vector3.down, out  hit, transform.rotation, 0.3f))
       // {
       //     
       //     Debug.DrawRay(pos, Vector3.down * 0.3f, Color.red);
       //     if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleTri") || hit.collider.CompareTag("ObstacleCol"))
       //     {
       //         _data.IsGrounded = true;
       //         return true;
       //     }
       // }
       


        if (_data.IsStiff == true || _data.IsGrounded == false) //물리적으로 밀쳐진 상태
        {
            Debug.Log("점프 불가 ! ");
            return false;
        }
        else
        {
            Debug.Log("점프 가능 ! ");
            return true;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 gizmos = new Vector3(transform.position.x, transform.position.y + _dropRayPosY, transform.position.z);

        Gizmos.DrawWireCube( gizmos,  _size);
    }
}
