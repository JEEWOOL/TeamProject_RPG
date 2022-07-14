using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������̺� �ʿ��� �Ŵ��� ���� �� ����� ���̱���
// protected ClassName() {} �������� �� �̱��� ������ ��� ����
namespace HOGUS.Scripts.DP
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;
        private static object lockObject = new ();
        private static bool applicationIsQuit = false;

        public static T Instance
        {
            get
            {
                if (applicationIsQuit)
                    return null;

                lock (lockObject)
                {
                    if (instance == null)
                    {
                        // �ν��Ͻ� ���� ���� Ȯ��
                        instance = (T)FindObjectOfType(typeof(T));

                        // �������� �ʾҴٸ� �ν��Ͻ� ����
                        if (instance == null)
                        {
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        }
                    }
                }
                return instance;
            }
        }

        protected void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void OnDestroy()
        {
            applicationIsQuit = true;
        }
    }
}