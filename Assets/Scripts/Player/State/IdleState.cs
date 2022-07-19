using HOGUS.Scripts.Character;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.State
{
    public class IdleState : IState
    {
        private readonly Player player;
        public IdleState(Player player)
        {
            this.player = player;
        }

        public void StateEnter()
        {
            Debug.Log("�÷��̾� ���޻��� ����");
        }

        public void StateExit()
        {
            Debug.Log("�÷��̾� ���޻��� ����");
        }

        public void StateFixedUpdate()
        {
        }

        public void StateUpdate()
        {
            if((player.HorizontalAxis != 0 || player.VerticalAxis != 0) && !player.IsSkill)
            {
                player.stateMachine.SetState(player.dicState[PlayerState.Move]);
            }
        }
    }
}