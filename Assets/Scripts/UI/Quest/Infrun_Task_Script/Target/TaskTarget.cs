using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskTarget : ScriptableObject
{
    // ����Ʈ �ý��ۿ� ����� Ÿ���� task�� ������ Ÿ�ٰ� ������ Ȯ��
    public abstract bool IsEqual(object target);

    // Ÿ���� �ܺη� ������ �� �ְ�
    // object���� ������ ���� Ÿ���� �ڷ����� �� Ŭ������ ��ӹ޴� �ڽĿ��� ������ ���̱� ����
    public abstract object Value { get; }
}
