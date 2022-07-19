using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Character;

namespace HOGUS.Scripts.CustomSystem
{
    /// <summary>
    /// ĳ������ ���� ���� �ý���
    /// </summary>
    public class CombatSystem : MonoBehaviour
    {
        public Transform attackPoint;
        public float attackRange = 0.5f;
        public LayerMask targetLayer;

        public void Attack()
        {
            // Detect specific LayerMask target in attackRange
            var hitTargets = Physics.OverlapSphere(attackPoint.position, attackRange, targetLayer);

            foreach (var target in hitTargets)
            {
                // �����Ϸ��� Character�� ����� Ư���� �����ͼ� �ؾ� ���� ������?
                
            }
        }
    }
}