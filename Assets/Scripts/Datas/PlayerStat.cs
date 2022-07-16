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
        protected float exp;
        [SerializeField]
        protected int gold;

        #endregion

        #region Player Stat Property
        public float EXP { get { return exp; } set { exp = value; } }
        public int Gold { get { return gold; } set { gold = value; } }

        #endregion
    }
}