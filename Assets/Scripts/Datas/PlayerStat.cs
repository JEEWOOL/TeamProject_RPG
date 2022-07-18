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
        protected float exp;        // ������ �� �ʿ��� ����ġ
        [SerializeField]
        protected float currExp;    // ���� ����ġ
        [SerializeField]
        protected int gold;

        #endregion

        #region Player Stat Property
        public float EXP { get { return exp; } set { exp = value; } }
        public float CurrentEXP { get { return currExp; } set { currExp = value; } }
        public int Gold { get { return gold; } set { gold = value; } }

        #endregion

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