using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Data
{
    public class PlayerStat : Stat
    {
        #region Player Stat Value
        [Header("�÷��̾� ���� ����")]
        [SerializeField]
        protected string characterClass; // ����
        [SerializeField]
        protected int strength;     // �� ����     -> 10�� �ּ�~�ִ� ������ 1�� ����
        [SerializeField]
        protected int magic;        // ���� ����   -> 10�� ���� ���ݷ� 3����
        [SerializeField]
        protected int dexterity;    // ��ø ����   -> 15�� ȸ���� 1�� ����
        [SerializeField]
        protected int vitality;     // Ȱ�� ����   -> 1�� �ִ�ü�� 1����
        [SerializeField]
        protected float exp;        // ������ �� �ʿ��� ����ġ
        [SerializeField]
        protected float currExp;    // ���� ����ġ
        [SerializeField]
        protected int gold;         // ���� ���
        [SerializeField]
        protected int statPoint;    // �����ִ� ���� ����Ʈ

        #endregion

        #region Player Stat Property
        public string CharacterClass { get { return characterClass; } set { characterClass = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public int Magic { get { return magic; } set { magic = value; } }
        public int Dexterity { get { return dexterity; } set { dexterity = value; } }
        public int Vitality { get { return vitality; } set { vitality = value;} }
        public float EXP { get { return exp; } set { exp = value; } }
        public float CurrentEXP { get { return currExp; } set { currExp = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public int StatPoint { get { return statPoint; } set { statPoint = value; } }
        #endregion

        public PlayerStat(PlayerStat copy)
        {
            strength = copy.strength;
            magic = copy.magic;
            Dexterity = copy.dexterity;
            Vitality = copy.vitality;
            minDamage = copy.minDamage;
            maxDamage = copy.maxDamage;
            defense = copy.defense;
            dodgeChance = copy.dodgeChance;
            speed = copy.speed;
            attackSpeed = copy.attackSpeed;
        }

#if UNITY_EDITOR
        public void PrintDebugStat()
        {
            Debug.Log($"level: {level}\nmaxHP: {maxHP}\ncurrHP: {currHP}\nminDamage: {minDamage}\n" +
                $"maxDamage: {maxDamage}\ndefense: {defense}\ndodgeChance: {dodgeChance}\nspeed: {speed}\n" +
                $"attackSpeed: {attackSpeed}\nexp: {exp}\ngole: {gold}");
        }
#endif
    }
}