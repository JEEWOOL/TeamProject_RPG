using UnityEngine;
using HOGUS.Scripts.Character;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.State
{
    public class AttackState : IState
    {
        private readonly Player player;
        public AttackState(Player player)
        {
            this.player = player;
        }

        public void StateEnter()
        {
            Debug.Log("�÷��̾� ���� ����");
            player.animator.SetTrigger("doWeaponAttack");
        }

        public void StateExit()
        {
            Debug.Log("�÷��̾� ���� ����");
        }

        public void StateFixedUpdate()
        {
        }

        public void StateUpdate()
        {
            if(player.animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Sword-Combo-Attack"))
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Idle]);
            }
        }
    }
}