using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New ArmorItem", menuName = "Scriptable Item Asset/Armor Item")]
    public class ArmorItem : EquipmentItem
    {
        [Header("�� ����")]
        public ArmorType type;

        [Header("����")]
        public int defense;

        public override void ApplyAbility()
        {
            throw new System.NotImplementedException();
        }

        public override string GetDescription()
        {
            return this.itemDescription;
        }
    }
}