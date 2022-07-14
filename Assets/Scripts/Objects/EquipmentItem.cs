using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOGUS.Scripts.Object.Item
{
    public abstract class EquipmentItem : BaseItem
    {
        [Header("������")]
        public int durability;

        [Header("���� ����")]
        public int socket;

        [Header("�䱸 �ɷ�ġ")]
        public int requireLevel;
        public int requireStrength;
        public int requireAgility;

        public abstract string GetDescription();
        public abstract void ApplyAbility();
    }
}
