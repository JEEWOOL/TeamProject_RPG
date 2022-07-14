using HOGUS.Scripts.Interface;
using UnityEngine;

namespace HOGUS.Scripts.DP
{
    [HelpURL("https://glikmakesworld.tistory.com/10?category=797136")]
    public class StateMachine
    {
        // ���� ���� ������Ƽ
        public IState CurrentState { get; private set; }

        // �⺻ ���¸� �����ڸ� ���� ������ ���ÿ� ����
        public StateMachine(IState defaultState)
        {
            CurrentState = defaultState;
        }

        // ���� ����
        public void SetState(IState state)
        {
            // ���°� �ߺ����� ���� ����
            if (CurrentState == state)
            {
                return;
            }

            // ���� ���� �켱 ����
            CurrentState.StateExit();
            // ���� ���� ����
            CurrentState = state;
            // ���� ����
            CurrentState.StateEnter();
        }

        // �� ������ �����ؾ� �� ���� ��� ����
        public void DoStateUpdate()
        {
            CurrentState.StateUpdate();
        }

        public void DoStateFixedUpdate()
        {
            CurrentState.StateFixedUpdate();
        }
    }
}
