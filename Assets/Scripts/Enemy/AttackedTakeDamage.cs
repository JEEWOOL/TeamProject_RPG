using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Character
{
    public class AttackedTakeDamage : MonoBehaviour
    {
        private CharacterStats stats;

        private void Awake()
        {
            stats = GetComponent<CharacterStats>();
        }
        //stat ���� �� �̸� ��������Ʈ�� �س���.
        public void OnAttack(GameObject attacker, Attack attack)
        {
            stats.Hp -= attack.Damage;
            if (stats.Hp <= 0)
            {
                stats.Hp = 0;
                //� ��Ȳ�� ���� �״°�찡 �����Ƿ� �������̽�ȭ�� �ϴ°� ����.
                var destructibles = GetComponentsInChildren<IDestructable>();  //�ڽı��� �� �����;��ϹǷ�
                foreach (var destructible in destructibles)
                {
                    destructible.OnDestruction(attacker);
                }
            }
        }
    }
}