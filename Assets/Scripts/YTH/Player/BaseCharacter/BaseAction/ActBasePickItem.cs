using System.Collections;
using UnityEngine;

public class ActBasePickItem : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] public Transform _handPosition; // 아이템을 들 위치(손)

    [SerializeField] private GameObject _item;

    [SerializeField] Animator _animator;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // 좌클릭 입력 시
        {
            Debug.Log("아이템 잡음");
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _data.HasItem = true;

            pickRoutine = StartCoroutine(PickRoutine());

            //아이템 주웠을 때 붙이고 다니는 기능

        }
    }

    Coroutine pickRoutine;
    IEnumerator PickRoutine()
    {
        WaitForSeconds dealy = new(0.4f);
        _animator.SetTrigger("PickItem");
        yield return dealy;
        _item.transform.position = _handPosition.position;
        _item.transform.SetParent(_handPosition);
        _item.transform.localPosition = Vector3.zero;
        pickRoutine = null;
    }


    
      
}
