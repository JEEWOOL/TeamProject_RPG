using HOGUS.Scripts.Character;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Enums;
namespace HOGUS.Scripts.State
{
    public class EnemyStateMove : IState
    {
        private HandMonster enemy;
        public EnemyStateMove(HandMonster e)
        {
            enemy = e;
        }
        public void StateEnter()
        {

        }
        public void StateUpdate()
        {
            // �̵����� ���� �������� �ƴ� ��
            
            // �̵����� 
        }
        public void StateExit()
        {

        }

        public void StateFixedUpdate()
        {

        }
    }
}