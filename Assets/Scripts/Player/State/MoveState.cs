using HOGUS.Scripts.Character;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.State
{
    public class MoveState : IState
    {
        private readonly Player player;
        public MoveState(Player player)
        {
            this.player = player;
        }

        public void StateEnter()
        {
            Debug.Log("�÷��̾� ������ ����");
        }

        public void StateExit()
        {
            Debug.Log("�÷��̾� ����");
        }

        public void StateFixedUpdate()
        {
        }

        public void StateUpdate()
        {
            if(player.IsSkill)
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Attack]);
                return;
            }

            if((player.HorizontalAxis == 0 && player.VerticalAxis == 0) && !player.IsSkill)
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Idle]);
                return;
            }
        }
    }
}
