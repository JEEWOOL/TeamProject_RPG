using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/Target/String", fileName = "Target_")]
public class StringTarget : TaskTarget
{
    // ���� Ȥ�� ���̵�� �޴� Ÿ��
    [SerializeField]
    private string value;

    public override object Value => value;

    public override bool IsEqual(object target)
    {
        string targetAsString = target as string; // Ÿ���� string������ ĳ����
        if(targetAsString == null)
        {
            // ���� Ÿ���� �ƴ϶�� ��
            return false;
        }
        // value ���� ���Ͽ� ĳ����
        return value == targetAsString;

        // ���� ��� ���� ������ value�� Slime�̶�� ���ڿ��̰�
        // ���� target�� Slime�̶�� ���ڿ��̶�� true�� ���ϵǾ�
        // ��ǥ�� �ϴ� target�� �´ٴ� ��
    }
}
