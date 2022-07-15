using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.DP;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New JewelItem", menuName = "Scriptable Item Asset/Jewel Item")]
    public class JewelItem : BaseItem
    {
        [Header("�߰� �ɷ�ġ")]
        public int additionalAbility;

        [Header("�߰� �ɷ�ġ ����")]
        public string optionDescription;

        [Header("���� ����")]
        public bool InsertSocket = false;

        public JewelItem(JewelItem item) : base(item)
        {
            this.additionalAbility = item.additionalAbility;
            this.optionDescription = item.optionDescription;
            this.InsertSocket = item.InsertSocket;
        }

        public void Attach(EquipmentItem equipment)
        {
            if (!CheckAbleIntoSocket(equipment))
                return;

            equipment.ApplyAbility(this.additionalAbility);
            SetDescription(equipment);
            equipment.socket--;
            InsertSocket = true;
        }

        private void SetDescription(EquipmentItem equipment)
        {
            equipment.itemDescription = string.Format("{0}\n{1}", equipment.GetDescription() ,optionDescription);
        }

        private bool CheckAbleIntoSocket(EquipmentItem equipment)
        {
            if(equipment.socket > 0 || !InsertSocket)
            {
                return true;
            }
            return false;
        }
    }
}
