using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New ShieldItem", menuName ="Scriptable Item Asset/Shield Item")]
    public class ShieldItem : EquipmentItem
    {
        [Header("����")]
        public int defense;

        [Header("���� Ȯ��")]
        public float blockChance;
    }
}