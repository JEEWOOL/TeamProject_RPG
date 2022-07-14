using HOGUS.Scripts.DP;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Manager;
using System.Collections.Generic;
using UnityEngine;


public class FPS_Check : MonoBehaviour, IUpdatableObject
{
    float deltaTime = 0.0f;

    // Ű������ ����� ���� ����
    private enum State
    {
        STOP,
        RUN,
    }
    // ��ü�� ���µ��� Ű, ����� ������ ��ųʸ�
    private Dictionary<State, IState> dictState = new();
    // fsm
    StateMachine stateMachine;

    private void Start()
    {
        // ���ǵ� ���� Ŭ������ ��ü ����
        var stateStop = new StateStop(this);
        var stateRun = new StateRun(this);

        // ������ ���� ��ü���� ��ųʸ��� Ű, ����� ����
        dictState.Add(State.STOP, stateStop);
        dictState.Add(State.RUN, stateRun);

        // fsm ���� �� Initial state �ʱ�ȭ
        stateMachine = new StateMachine(stateRun);
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0}?ms?({1:0.}?fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    public void OnEnable()
    {
        UpdateManager.Instance.RegisterUpdatableObject(this);
    }

    public void OnDisable()
    {
        UpdateManager.Instance.DeregisterUpdatableObject(this);
    }

    public void OnUpdate()
    {
    }

    public void OnFixedUpdate()
    {
    }

    public void OnUpdate(float deltaTime)
    {
        // fsm�� ����� ���� ���°� StateRun
        if (stateMachine.CurrentState == dictState[State.RUN])
        {
            this.deltaTime += (deltaTime - this.deltaTime) * 0.1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SetState(dictState[State.STOP]);
            }
        }
        // fsm�� ����� ���� ���°� StateStop
        else if (stateMachine.CurrentState == dictState[State.STOP])
        {
            this.deltaTime = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SetState(dictState[State.RUN]);
            }
        }
    }
}

#region states
// �����ִ� ����
public class StateStop : IState
{
    // ���¸� �����ϰ� �ִ� Ŭ���� ��ü ����
    private FPS_Check fps_Check;

    // �����ڸ� ���� ���¸� �����ϰ� �ִ� ��ü�� ����
    public StateStop(FPS_Check FC)
    {
        fps_Check = FC;
    }

    public void StateEnter()
    {
        Debug.Log("State Stop Enter");
    }

    public void StateExit()
    {
        Debug.Log("State Stop Exit");
    }

    public void StateFixedUpdate()
    {
    }

    public void StateUpdate()
    {
    }
}

public class StateRun : IState
{
    private FPS_Check fps_Check;

    public StateRun(FPS_Check FC)
    {
        fps_Check = FC;
    }

    public void StateEnter()
    {
        Debug.Log("State Run Enter");
    }

    public void StateExit()
    {
        Debug.Log("State Run Exit");
    }

    public void StateFixedUpdate()
    {
    }

    public void StateUpdate()
    {
    }
}
#endregion