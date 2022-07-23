using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New ShieldItem", menuName ="Scriptable Item Asset/Shield Item")]
    public class ShieldItem : EquipmentItem
    {
        [Header("����")]
        public int defense;

        [Header("���� Ȯ��")]
        public float blockChance;

        [Header("���� ����")]
        public ShieldType type;

        public void CopyValue(ShieldItem item)
        {
            base.CopyValue(item);
            defense = item.defense;
            blockChance = item.blockChance;
        }

        public override void ApplyAbility(int add)
        {
            defense += add;
        }

        public override string GetDescription()
        {
            return this.itemDescription;
        }
    }
}