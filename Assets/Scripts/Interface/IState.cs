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
        /// ���� ���� �������� ���������� ȣ��� ���� ����
        /// </summary>
        void StateFixedUpdate();
        /// <summary>
        /// ���� ���� �� ������ ȣ��� ���� ����
        /// </summary>
        void StateUpdate();
        /// <summary>
        /// ���� ��� �� ���� ����
        /// </summary>
        void StateExit();

    }
}