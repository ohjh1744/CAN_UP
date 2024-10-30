using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle13 : MonoBehaviour, IResetObject
{
    private Quaternion _startRot;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    [SerializeField] private float _rotateSpeed;

    [SerializeField] private float _rotateAngle;

    [SerializeField] private Rigidbody _rigid;

    private Coroutine _rotateRoutine;

    private void Start()
    {
        _startRot = transform.rotation;
    }

    public void RotatePlatform(PlayerController player)
    {
        Debug.Log("fsda");
        StartCoroutine(RotateRoutine(_rotateAngle));
    }

    IEnumerator RotateRoutine(float rotateAngle)
    {
        float startRot = gameObject.transform.eulerAngles.z;
        float endRot = rotateAngle;

        float rot = 0f;

        while (rot < 1.5f)
        {
            rot += Time.deltaTime;
            _rotateSpeed = rot;
            float zRotation = Mathf.Lerp(startRot, endRot, _rotateSpeed) % 360.0f;

            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, zRotation);

            yield return null;
        }
    }

    public void Reset()
    {
        transform.rotation = _startRot;
    }
}
