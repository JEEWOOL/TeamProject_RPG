using HOGUS.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Data
{
    [CreateAssetMenu(fileName = "New PlayerStat", menuName = "Scriptable Stat/playerStat")]
    public class PlayerStat : Stat
    {
        #region Player Stat Value
        [Header("�÷��̾� ���� ����")]
        [SerializeField]
        protected string characterClass; // ����
        [SerializeField]
        protected int strength;     // �� ����     -> 5�� �ּ�~�ִ� ������ 1�� ����
        [SerializeField]
        protected int magic;        // ���� ����   -> 5�� ���� ���ݷ� 3����, ���� 5����
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
        [SerializeField]
        protected int curMP;
        [SerializeField]
        protected int maxMP;
        [SerializeField]
        protected int magicDamage; 
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
        public int CurMP { get { return curMP; } set { curMP = value; } }
        public int MaxMP { get { return maxMP; } set { maxMP = value; } }
        public int MagicDamage { get { return magicDamage; } set { magicDamage = value; } }
        #endregion

        public void AddStat(int index)
        {
            switch (index)
            {
                case PlayerStatEnumClass.STR:
                    Strength++;
                    break;
                case PlayerStatEnumClass.MAGIC:
                    Magic++;
                    break;
                case PlayerStatEnumClass.DEX:
                    Dexterity++;
                    break;
                case PlayerStatEnumClass.VITAL:
                    Vitality++;
                    break;
            }
        }

        #region Stat Unit
        public readonly int DamagePerStrength = 5;
        public readonly int DamagePerMagic = 5;
        public readonly int DodgePerDex = 15;
        public readonly int HPPerVital = 1;
        #endregion

#if UNITY_EDITOR
        public void PrintDebugStat()
        {
            Debug.Log($"level: {level}\nmaxHP: {maxHP}\ncurrHP: {curHP}\nminDamage: {minDamage}\n" +
                $"maxDamage: {maxDamage}\ndefense: {defense}\ndodgeChance: {dodgeChance}\nspeed: {speed}\n" +
                $"attackSpeed: {attackSpeed}\nexp: {exp}\ngole: {gold}");
        }
#endif
    }
}