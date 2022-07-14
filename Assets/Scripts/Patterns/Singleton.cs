namespace HOGUS.Scripts.DP
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (!Exist())
                {
                    instance = new();
                }
                return instance;
            }
        }

        // �ν��Ͻ��� ����������� Ȯ��
        public static bool Exist()
        {
            return instance != null;
        }

        // �ν��Ͻ� �����̷� �ʱ�ȭ
        public static void ClearInstance()
        {
            instance = null;
        }
    }
}