namespace HOGUS.Scripts.Interface
{
    public interface IState
    {
        /// <summary>
        /// ���� ���� �� ���� ����
        /// ex) �ൿ ���� �� �ִϸ��̼� ����
        /// </summary>
        void StateEnter();
        /// <summary>
        /// ���� ��� �� ���� ����
        /// ex) �ൿ ���� �� �ִϸ��̼� ����
        /// </summary>
        void StateUpdate();
        /// <summary>
        /// ���� ���� �� ������ ȣ��� ���� ����
        /// </summary>
        void StateExit();
    }
}