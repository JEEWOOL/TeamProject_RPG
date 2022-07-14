using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New WeaponItem", menuName = "Scriptable Item Asset/Weapon Item")]
    public class WeaponItem : EquipmentItem
    {
        [Header("���� ����")]
        public WeaponType type;

        [Header("�ּ�-�ִ� ������")]
        public int minDamage;
        public int maxDamage;

        [Header("���ݼӵ�")]
        public int attackSpeed;
    }
}
