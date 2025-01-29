using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class MaterialChanger : MonoBehaviour
{
    // GameSceneManager Ŭ���� ������
    [SerializeField] private GameSceneContext _gameSceneManager;

    // �������� �� ��� ��ī�̹ڽ� ���͸��� ����� �迭
    [SerializeField] private Material[] _skyMaterials;

    private void Start()
    {
        // CharacterNum �������� 0��° �׸��� ���� ���� ó��
        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return;

        // ó�� ��ī�̹ڽ��� ���͸��� ����
        RenderSettings.skybox = _skyMaterials[0];
    }

    private void Update()
    {
        // ��ī�̹ڽ� ���͸��� ��ü�� �ݺ���
        for (int i = 0; i < _skyMaterials.Length; i++)
        {
            // ���� �÷��̾��� y��ǥ���� �������� ���氪���� ���� ���
            if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 1]
                && _gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 2])
            {
                Debug.Log("sadgasdge");
                // i��°(���� ��������) ��ī�̹ڽ� ���͸���� ��ī�̹ڽ��� ����
                RenderSettings.skybox = _skyMaterials[i + 1];
                return;
            }
            //// ���� �÷��̾��� y��ǥ���� �������� ���氪 ������ ���
            //else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 1]
            //    && _gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 2])
            //{
            //    // i - 1��°(���� ��������) ��ī�̹ڽ� ���͸���� ��ī�̹ڽ��� ����
            //    RenderSettings.skybox = _skyMaterials[i];
            //}
        }
    }
}

