using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Manager;

namespace HOGUS.Scripts.DP
{
    [System.Serializable]
    public class ObjectInfo
    {
        public string objectName;   // ������Ʈ�� �̸�
        public GameObject prefab;   // ���� ������
        public int count;           // ������ ������Ʈ�� ����
    }

    public class ObjectPool : MonoSingleton<ObjectPool>
    {
        [SerializeField]
        private ObjectInfo[] objectInfos = null;

        [Header("������Ʈ Ǯ�� �θ� ��ġ")]
        Transform trParent;

        [Header("������Ʈ �迭 ť")]
        public List<Queue<GameObject>> objectPoolList;

        private void Start()
        {
            GameManager.Instance.objectPool += SelectPoolList;
            GameManager.Instance.returnPool += ReturnPool;

            objectPoolList = new();
            ObjectPoolState();
        }

        private void ObjectPoolState()
        {
            if (objectPoolList != null)
            {
                for (int i = 0; i < objectInfos.Length; i++)
                {
                    objectPoolList.Add(InsertQueue(objectInfos[i]));
                }
            }
        }

        private Queue<GameObject> InsertQueue(ObjectInfo objectInfo)
        {
            Queue<GameObject> queue = new();

            for (int i = 0; i < objectInfo.count; i++)
            {
                GameObject objectClone = Instantiate(objectInfo.prefab) as GameObject;
                objectClone.SetActive(false);
                objectClone.transform.SetParent(trParent);
                queue.Enqueue(objectClone);
            }
            return queue;
        }

        // ������Ʈ Ǯ���� ���õ� �ε����� ��ü�� ������ ����� ��
        private GameObject SelectPoolList(int idx)
        {
            return objectPoolList[idx].Dequeue();
        }
        // ����� �ε����� Ǯ ��ü �ݳ��� �� ���
        private void ReturnPool(int idx, GameObject poolObject)
        {
            objectPoolList[idx].Enqueue(poolObject);
        }

        // test code
        // 0�� ����Ʈ�� ����� ������Ʈ�� ������
        // GameObject damagePrefab = GameManager.Instance.objectPool.Invoke(0);
        // 0�� ����Ʈ�� ������Ʈ�� �ݳ�
        // GamaManager.Instance.returnPool.Invoke(0, this.gameObject);
    }
}