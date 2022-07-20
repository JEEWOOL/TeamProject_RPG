using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TaskState
{
    Inactive,
    Running,
    Complete,
}

[CreateAssetMenu(menuName = "Quest/Task/Task", fileName = "Task_")]
public class Task : ScriptableObject
{
    #region Events
    public delegate void StateChangedHandler(Task task, TaskState currentState, TaskState prevState);
    public delegate void SuccessChangedHandler(Task task, int currentSuccess, int prevSuccess);
    #endregion

    [SerializeField]
    private Category category;

    [Header("Task ����")]
    [SerializeField]
    private string codeName;        // �˻��� ���� ��� ����� ���� ���������� ����ϴ� �̸�
    [SerializeField]
    private string description;     // task�� ���� ����

    [Header("Action")]
    [SerializeField]
    private TaskAction action;

    [Header("Target")]
    [SerializeField]
    private TaskTarget[] targets;   // Ÿ���� ���� ���� ���� �ֱ� ����

    [Header("Task ����")]
    [SerializeField]
    private InitialSuccessValue initialSuccessValue;
    [SerializeField]
    private int needSuccessToComplete;
    [SerializeField]
    private bool canReceiveReportsDuringCompleTion; // ����Ʈ�� �Ϸ�Ǿ��� ������ ��� ����Ƚ���� ���� ���� ������?

    private TaskState state;
    private int currentSuccess;

    public event StateChangedHandler onStateChanged;
    public event SuccessChangedHandler onSuccessChanged;    

    public int CurrentSuccess
    {
        get => currentSuccess;
        set
        {
            int prevSuccess = currentSuccess;
            currentSuccess = Mathf.Clamp(value, 0, needSuccessToComplete);
            if(currentSuccess != prevSuccess)
            {
                state = currentSuccess == needSuccessToComplete ? TaskState.Complete : TaskState.Running;
                onSuccessChanged?.Invoke(this, currentSuccess, prevSuccess);
            }

        }
    }

    public Category Category => category;
    public string CodeName => codeName;
    public string Description => description;
    public int NeedSuccessToComlete => needSuccessToComplete;
    
    public TaskState State
    {
        get => state;
        set
        {
            var prevState = state;
            state = value;
            onStateChanged?.Invoke(this, state, prevState); // ?. �� ������ null�̸� null ��ȯ �ƴ� �� �Լ� ����
        }
    }

    public bool IsComplete => State == TaskState.Complete;

    public Quest Owner { get; private set; }

    public void SetUp(Quest owner)
    {
        Owner = owner;
    }

    public void Start()
    {
        State = TaskState.Running;
        if(initialSuccessValue)
        {
            CurrentSuccess = initialSuccessValue.GetValue(this);
        }
    }

    public void End()
    {
        onStateChanged = null;
        onSuccessChanged = null;
    }

    public void Complete()
    {
        CurrentSuccess = needSuccessToComplete;
    }

    public void ReceiveReport(int _successCount)
    {
        // action.Run()�Լ��� Logic�� ������ ����� ��ȯ
        // Count�ϴ� ������ ��� CurrentSuccess�� _successCount�� �������� ��ȯ
        CurrentSuccess = action.Run(this, CurrentSuccess, _successCount);
    }

    // Any() https://docs.microsoft.com/ko-kr/dotnet/api/system.linq.enumerable.any?view=net-6.0
    public bool IsTarget(string _category ,object target)
        => Category == _category &&
        (!IsComplete || (IsComplete && canReceiveReportsDuringCompleTion)) &&
        targets.Any(x => x.IsEqual(target));     // �������� ��Ұ� �ϳ��� �ִ��� �Ǵ� Ư�� ���ǿ� �´� ��Ұ� �ִ��� Ȯ��
                                                    // Task�� ����Ƚ���� ���� ���� ������� Ȯ���ϴ� �Լ�
                                                    // �����س��� Ÿ�ٵ� �߿� ����� ������ Ʈ�� �ƴϸ� �޽�
}
