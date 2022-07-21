using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Character;
using HOGUS.Scripts.Object.Item;

namespace HOGUS.Scripts.CustomSystem
{
    /// <summary>
    /// ĳ������ ���� ���� �ý���
    /// </summary>
    public class CombatSystem : MonoBehaviour
    {
        public GameObject attackCollider;

        public void OnAttackCollision()
        {
            attackCollider.SetActive(true);
        }
    }
}