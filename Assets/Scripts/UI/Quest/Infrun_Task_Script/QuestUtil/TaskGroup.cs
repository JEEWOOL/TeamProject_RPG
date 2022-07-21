using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TaskGroupState
{
    Inactive,
    Running,
    Complete,
}

[System.Serializable]
public class TaskGroup
{
    [SerializeField]
    private Task[] tasks;

    public IReadOnlyList<Task> Tasks => tasks;
    public Quest Owner { get; private set; }
    public bool IsAllTaskComplete => tasks.All(x => x.IsComplete);
    public bool IsComplete => State == TaskGroupState.Complete;

    public TaskGroupState State { get; private set; }
    
    // Ŭ�δ� ����
    // �ٸ� TaskGroup�� ī���ϴ� ������
    public TaskGroup(TaskGroup _CopyTarget)
    {
        tasks = _CopyTarget.tasks.Select(x => Object.Instantiate(x)).ToArray();
    }

    public void SetUp(Quest _owner)
    {
        Owner = _owner;
        foreach (var task in tasks)
        {
            task.SetUp(_owner);
        }
    }

    public void Start()
    {
        // Quest�� ���� ���� ���� TaskGroup �߿� ���� �۵��ؾ� �ϴ� TaskGroup ���۵� �� ����
        State = TaskGroupState.Running;
        foreach (var task in tasks)
        {
            task.Start();
        }
    }

    public void End()
    {
        foreach(var task in tasks)
        {
            task.End();
        }
    }

    public void ReceiveReport(string _category, object _target, int _successCount)
    {
        // task�� �ش� ī�װ��� Ÿ���� ���� ������ ���� �޴´�.
        foreach (var task in tasks)
        {
            if(task.IsTarget(_category, _target))
            {
                task.ReceiveReport(_successCount);
            }
        }
    }
    
    public void Complete()
    {
        if(IsComplete)
        {
            return;
        }
        State = TaskGroupState.Complete;
        foreach(var task in tasks)
        {
            if(!task.IsComplete)
            {
                task.Complete();
            }
        }
    }

}
