using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New WeaponItem", menuName = "Scriptable Item Asset/Weapon Item")]
    public class WeaponItem : EquipmentItem
    {
        [Header("���� ������ Address")]
        public string refAddress;

        [Header("���� ����")]
        public WeaponType type;

        [Header("�ּ�-�ִ� ������")]
        public int minDamage;
        public int maxDamage;

        [Header("���ݼӵ�")]
        public float attackSpeed;

        public void CopyValue(WeaponItem item)
        {
            base.CopyValue(item);

            refAddress = item.refAddress;
            type = item.type;
            minDamage = item.minDamage;
            maxDamage = item.maxDamage;
            attackSpeed = item.attackSpeed;
        }

        public override void ApplyAbility(int add)
        {
            minDamage += add;
            maxDamage += add;
        }

        public override string GetDescription()
        {
            return this.itemDescription;
        }
    }
}
