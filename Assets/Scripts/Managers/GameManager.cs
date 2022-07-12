using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.DP;

namespace HOGUS.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public void TestLog() => Debug.Log("���� �Ŵ���");

        // ObjectPool delegate
        public Func<int, GameObject> objectPool;
        public Action<int, GameObject> returnPool;
    }
}
