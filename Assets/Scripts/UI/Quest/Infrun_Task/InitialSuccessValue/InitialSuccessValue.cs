using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/Action/ContinousCount", fileName = "ContinousCount")]
public abstract class InitialSuccessValue : ScriptableObject
{
    // Task�� �ʱ� ���� ���� �������ִ� Ŭ����
    // ���� ���� ���� �ʱ� ���� ���� �޸��شٰų�..
    public abstract int GetValue(Task task);
}
