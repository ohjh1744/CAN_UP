using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //collision
    // Player�� ���˽� �߻��ϴ� �Լ�
    void TargetInteractColEnter(PlayerController player);

    // Player�� �����߿� �߻��ϴ� �Լ�
    void TargetInteractColStay(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractColExit(PlayerController player);

    //trigger
    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriEnter(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriStay(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriExit(PlayerController player);

    // Item���� ��ȣ�ۿ� �Լ���
    void TargetInteractColEnter(Item item);

    void TargetInteractColStay(Item item);

    void TargetInteractColExit(Item item);

    void TargetInteractTriEnter(Item item);

    void TargetInteractTriStay(Item item);

    void TargetInteractTriExit(Item item);

}
