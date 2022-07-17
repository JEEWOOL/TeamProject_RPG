using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Data
{
    [System.Serializable]
    public class Stat : MonoBehaviour
    {
        #region Base Stat value
        [Header("ĳ���� �⺻ ����")]
        [SerializeField]
        protected int level;           // ĳ������ ����
        [SerializeField]
        protected int maxHP;           // ĳ������ �ִ� ü��
        [SerializeField]
        protected int currHP;          // ĳ������ ���� ü��
        [SerializeField]
        protected int minDamage;       // ĳ������ �ּ� ���ݷ�
        [SerializeField]
        protected int maxDamage;       // ĳ������ �ִ� ���ݷ�
        [SerializeField]
        protected int defense;         // ĳ������ ����
        [SerializeField]
        protected float dodgeChance;   // ĳ������ ȸ����
        [SerializeField]
        protected float speed;         // ĳ������ �̵� �ӵ�
        [SerializeField]
        protected float attackSpeed;   // ĳ������ ���� �ӵ�
        #endregion

        #region Base Stat Property
        public int Level { get { return level; } set { level = value; } }
        public int MaxHP { get { return maxHP; } set { maxHP = value; } }
        public int CurHP { get { return currHP; } set { currHP = value; } }
        public int MinDamage { get { return minDamage; } set { minDamage = value; } }
        public int MaxDamage { get { return maxDamage; } set { maxDamage = value; } }
        public int Defense { get { return defense; } set { defense = value; } }
        public float DodgeChance { get { return dodgeChance; } set { dodgeChance = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }
        #endregion
    }
}
