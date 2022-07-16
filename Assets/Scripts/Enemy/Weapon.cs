using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Character
{
    [CreateAssetMenu(fileName = "Weapon.asset", menuName = "Attack/Weapon")] // ���¿� ������ �߰� ���������� ������Ʈ�� �߰�
    public class Weapon : AttackDefinition
    {
        public GameObject prefab;

        public void ExecuteAttack(GameObject attacker, GameObject defender)
        {
            if (defender == null)
            {
                return;
            }

            // �Ÿ�
            if (Vector3.Distance(attacker.transform.position, defender.transform.position) > range)
            {
                return;
            }

            // ����
            var dir = defender.transform.position - attacker.transform.position;
            dir.Normalize();
            var dot = Vector3.Dot(attacker.transform.forward, dir);

            if (dot < 0.5f)
            {
                return;
            }

            // ����
            var aStates = attacker.GetComponent<CharacterStats>();
            var dStates = defender.GetComponent<CharacterStats>();
            var attack = CreateAttack(aStates, dStates);

            var attackables = defender.GetComponentsInChildren<IAttackable>();
            foreach (var attackable in attackables)
            {
                attackable.OnAttack(attacker, attack);
            }

        }
    }
}