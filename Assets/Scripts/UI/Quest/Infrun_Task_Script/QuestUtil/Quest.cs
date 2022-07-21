using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using UnityEngine;

//using Debug = UnityEngine.Debug;

public enum QuestState
{
    Inactive,
    Running,
    Complete,
    Cancel,
    WaitForCompletion,
}

[CreateAssetMenu(menuName = "Quest/Quest", fileName = "Quest_")]
public class Quest : ScriptableObject
{
    #region Events
    public delegate void TaskSuccessChangeHandler(Quest quest, Task task, int currentSuccess, int prevSuccess);
    public delegate void CompletedHandler(Quest quest);
    public delegate void CancelHandler(Quest quest);
    public delegate void NewTaskGroupHandler(Quest quest, TaskGroup currentTaskGroup, TaskGroup prevTaskGroup);
    #endregion

    [SerializeField]
    private Category category;
    [SerializeField]
    private Sprite icon;

    [Header("����Ʈ �Ӽ�")]
    [SerializeField]
    private string codeName;
    [SerializeField]
    private string displayName;
    [SerializeField, TextArea]
    private string description;

    [Header("Task")]
    [SerializeField]
    private TaskGroup[] taskGroups;

    [Header("����Ʈ ����")]
    [SerializeField]
    private Reward[] rewards;

    [Header("�ɼ�")]
    [SerializeField]
    private bool useAutoComplete;
    [SerializeField]
    private bool isCancelable;
    [SerializeField]
    private bool isSavable;     // save�� ������ üũ

    [Header("����Ʈ ����")]
    [SerializeField]
    private Condition[] acceptionConditions;
    [SerializeField]
    private Condition[] cancelConditions;

    private int currentTaskGroupIndex;

    public Category Category => category;
    public Sprite Icon => icon; 
    public string CodeName => codeName;
    public string DisplayName => displayName;
    public string Description => description;
    public QuestState State { get; private set; }
    // �������� 10���� ��ƶ�
    //
    // ���� �������� 10���� ��ƶ�
    // ��� �������� 10���� ��ƶ� -> �׸� �������� 10���� ��ƶ�

    public TaskGroup CurrentTaskGroup //=> taskGroups[currentTaskGroupIndex];
    {
        get 
        {
            return taskGroups[currentTaskGroupIndex]; 
        }
    }

    public IReadOnlyList<TaskGroup> TaskGroups => taskGroups;
    public IReadOnlyList<Reward> Rewards => rewards;
    public bool IsRegistered => State != QuestState.Inactive;
    public bool IsCompletable => State == QuestState.WaitForCompletion;
    public bool IsComplete => State == QuestState.Complete;
    public bool IsCancel => State == QuestState.Cancel;
    public virtual bool IsCancelable => isCancelable && cancelConditions.All(x => x.IsPass(this));
    public bool IsAcceptable => acceptionConditions.All(x => x.IsPass(this));
    public virtual bool IsSavable => isSavable;     // ������ ���̺� �Ǿ� �ϴ� �������� ����

    public event TaskSuccessChangeHandler onTaskSuccessChanged;
    public event CompletedHandler onCompleted;
    public event CancelHandler onCanceled;
    public event NewTaskGroupHandler onNewTaskGroup;

    public void OnRegister()
    {
        // ���ڷ� ���� ���� false�� ������ error�� ����ش�.
        Debug.Assert(!IsRegistered, "This quest has already been registered.");

        foreach(var taskGroup in taskGroups)
        {
            taskGroup.SetUp(this);
            foreach(var task in taskGroup.Tasks)
            {
                task.onSuccessChanged += OnSuccessChanged;
            }
        }

        State = QuestState.Running;
        CurrentTaskGroup.Start();
    }

    public void ReceiveReport(string _category, object _target, int _successCount)
    {
        Debug.Assert(IsRegistered, "This quest has already been registered.");
        Debug.Assert(!IsCancel, "This quest has been canceled");

        if (IsComplete)
            return;
        CurrentTaskGroup.ReceiveReport(_category, _target, _successCount);   

        if(CurrentTaskGroup.IsAllTaskComplete)
        {
            if(currentTaskGroupIndex + 1 == taskGroups.Length) // ���� TaskGroup�� ���ٸ�
            {
                State = QuestState.WaitForCompletion;
                if(useAutoComplete) // �ڵ����� ����Ʈ�� ������ useAutoComplete�� Ȱ��ȭ ���ִٸ�
                {
                    Complete();
                }
                else // // ���� TaskGroup�� �ִٸ�
                {
                    var prevTaskGroup = taskGroups[currentTaskGroupIndex++]; // ���� taskGroup�� �������鼭 �ε��� ������Ű��
                    prevTaskGroup.End(); // ���� taskGroup�� ������
                    CurrentTaskGroup.Start(); // ���� taskGroup�� ����
                    onNewTaskGroup?.Invoke(this, CurrentTaskGroup, prevTaskGroup); // ���ο� taskGroup�� ���۵ƴٴ� ���� �̺�Ʈ�� ���� �˷��ش�.
                }
            }
        }
        else
        {
            // �ٽ� task�� �� ���� ���°� �� �� �ֱ� ����
            State = QuestState.Running;
        }
    }

    public void Complete()
    {
        // ����Ʈ ��� �Ϸ����ִ� �������̳� �ý��ۿ� ���ؼ� ����Ʈ�� task�� �Ϸ���� �ʾ����� Complete�ϴ� ���

        CheckIsRunning();

        foreach (var taskGroup in taskGroups)
        {
            taskGroup.Complete();
        }

        State = QuestState.Complete;

        foreach(var reward in rewards)
        {
            reward.Give(this);
        }

        onCompleted?.Invoke(this);

        onTaskSuccessChanged = null;
        onCompleted = null;
        onCanceled = null;
        onNewTaskGroup = null;
    }

    public virtual void Cancel()
    {
        CheckIsRunning();
        Debug.Assert(IsCancelable, "this quest can't be canceled");

        State = QuestState.Cancel;
        onCanceled?.Invoke(this);
    }

    // Ŭ�δ� ����
    public Quest Clone()
    {
        var clone = Instantiate(this);
        clone.taskGroups = taskGroups.Select(x => new TaskGroup(x)).ToArray();

        return clone;
    }

    public QuestSaveData ToSaveData()
    {
        return new QuestSaveData
        {
            codeName = codeName,
            state = State,
            taskGroupIndex = currentTaskGroupIndex,
            taskSuccessCounts = CurrentTaskGroup.Tasks.Select(x => x.CurrentSuccess).ToArray()
        };
    }

    public void LoadFrom(QuestSaveData saveData)
    {
        State = saveData.state;
        currentTaskGroupIndex = saveData.taskGroupIndex;

        for (int i = 0; i < currentTaskGroupIndex; i++)
        {
            var taskGroup = taskGroups[i];
            taskGroup.Start();
            taskGroup.Complete();
        }

        for (int i = 0; i < saveData.taskSuccessCounts.Length; i++)
        {
            CurrentTaskGroup.Start();
            CurrentTaskGroup.Tasks[i].CurrentSuccess = saveData.taskSuccessCounts[i];
        }
    }

    private void OnSuccessChanged(Task task, int currentSuccess, int prevSuccess)
        => onTaskSuccessChanged?.Invoke(this, task, currentSuccess, prevSuccess);

    [Conditional("UNITY_EDITOR")] // ���ڷ� ������ Simbol ���� ����Ǿ� ������ �Լ� ����
    private void CheckIsRunning()
    {
        Debug.Assert(IsRegistered, "This quest has already been registered.");
        Debug.Assert(!IsCancel, "This quest has been canceled");
        Debug.Assert(!IsComplete, "This quest has already been Completed");
    }
}

