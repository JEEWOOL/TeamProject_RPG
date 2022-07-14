using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.DP;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New JewelItem", menuName = "Scriptable Item Asset/Jewel Item")]
    public class JewelItem : Decorator
    {
        [Header("�߰� �ɷ�ġ")]
        public int additionalAbility;

        [Header("�߰� �ɷ�ġ ����")]
        public string optionDescription;

        [Header("���� ����")]
        public bool InsertSocket = false;

        public JewelItem(WeaponItem weapon)
        {
            this.equipment = weapon;
        }

        public override void ApplyAbility()
        {
            InsertSocket = true;
        }

        public override string GetDescription()
        {
            return $"{this.equipment.GetDescription()}\n{optionDescription}";
        }
    }
}
