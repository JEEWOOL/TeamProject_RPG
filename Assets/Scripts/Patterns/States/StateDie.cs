using HOGUS.Scripts.Interface;

namespace HOGUS.Scripts.DP
{
    public class StateDie : IState
    {
        public void StateEnter()
        {
            Debug.Log("����");
        }

        public void StateUpdate()
        {
            Debug.Log("��������");
        }
        public void StateExit()
        {
            Debug.Log("�����");
        }
    }
}