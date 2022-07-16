using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Character
{
    public class AttackedForce : MonoBehaviour, IAttackable
    {
        public float force = 10f;
        public float up = 0.5f;
        private Rigidbody rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        public void OnAttack(GameObject attacker, Attack attack)
        {
            var dir = transform.position - attacker.transform.position;
            dir.y = up;
            dir.Normalize();

            rigid.AddForce(dir * force, ForceMode.Impulse); // impulse �߻�ü ������ ���


            //rigid -> ���� �ο��ϴ� ���? (�˹�)
        }
    }
}