using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Character
{
[CreateAssetMenu(fileName = "Attack.asset", menuName = "Attack/BaseAttack")] // ���¿� ������ �߰� ���������� ������Ʈ�� �߰�

    public class AttackDefinition : ScriptableObject
    {
        public float cooldown;
        public float range;
        public float minDamage;
        public float maxDamage;
        public float criticalChance;
        public float criticalMultiplier;

        public Attack CreateAttack(CharacterStats attacker, CharacterStats defender)
        {
            float damage = attacker.damage;
            damage += Random.Range(minDamage, maxDamage);

            bool isCritical = Random.value < criticalChance;
            if (isCritical)
            {
                damage *= criticalMultiplier;
            }
            if (defender != null)
            {
                damage -= defender.armor;
            }

            return new Attack((int)damage, isCritical);
        }
    }
}