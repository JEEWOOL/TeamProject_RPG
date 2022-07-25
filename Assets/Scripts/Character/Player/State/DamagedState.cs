using UnityEngine;
using HOGUS.Scripts.Character;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.State
{
    public class DamagedState : IState
    {
        private readonly Player player;

        public DamagedState(Player player)
        {
            this.player = player;
        }

        public void StateEnter()
        {
            Debug.Log("�ǰ� ����");
        }

        public void StateExit()
        {
            Debug.Log("�ǰ� ���� ����");
        }

        public void StateFixedUpdate()
        {
        }

        public void StateUpdate()
        {
            if(player.moveDir != Vector3.zero)
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Move]);
            }
            // �ǰ� ���´� �ڷ�ƾ�� ����ʰ� ���ÿ� ���� �Ǿ�� ��
            if(!player.Immune)
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Idle]);
            }
        }
    }
}