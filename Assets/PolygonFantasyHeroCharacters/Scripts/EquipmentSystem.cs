using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using HOGUS.Scripts.Enums;
using HOGUS.Scripts.Object.Item;

namespace HOGUS.Scripts.CustomSystem
{
    /// <summary>
    /// ĳ������ ��� �������� ����, ������ ������� �ý���
    /// </summary>
    public class EquipmentSystem : MonoBehaviour
    {
        public Player player;
        private GameObject weaponGO;

        public WeaponItem equipWeapon;
        public ShieldItem equipShield;
        // ��� ������ ���� ���¸� ��Ÿ���� ��ųʸ�
        public Dictionary<EquipPart, ArmorItem> dictEquipmets = new();

        /// <summary>
        /// �� ������ ���� �Լ�
        /// </summary>
        public void DoEquip(EquipPart part, ArmorItem armorItem)
        {
            // ���� �ش� ������ �����ϰ� �ִٸ� ���� ���� �� ��ȯ
            if (dictEquipmets.ContainsKey(part))
            {
                DoUnequip(part);
            }
            else
            {
                //player.equipedDefense += armorItem.defense;
            }
            dictEquipmets.Add(part, armorItem);
        }

        /// <summary>
        /// ���� ������ ���� �Լ�
        /// </summary>
        public void DoEquip(EquipPart part, WeaponItem weaponItem)
        {
            if (equipWeapon != null)
            {
                DoUnequip(part);
            }
            
            equipWeapon = weaponItem;

            if (part == EquipPart.WEAPON)
            {
                WeaponItem weaponPart = equipWeapon;
                AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(weaponPart.refAddress);
                handle.Completed += AsyncOperationHandle_Complete;
            }
        }

        /// <summary>
        /// �Էµ� ��Ʈ�� ��� ����
        /// </summary>
        public void DoUnequip(EquipPart part)
        {
            if(part == EquipPart.WEAPON)
            {
                // �κ��丮 ���� �� ���� ���� ������ 
                // ���� �����ؼ� �κ��丮�� �ֱ�
                equipWeapon = null;
                if(weaponGO != null)
                {
                    Destroy(weaponGO);
                }
            }
            else
            {
                //player.equipedDefense -= dictEquipmets[part].defense;
                dictEquipmets.Remove(part);
            }

        }

        private void AsyncOperationHandle_Complete(AsyncOperationHandle<GameObject> handle)
        {
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                weaponGO = Instantiate(handle.Result, player.weaponEquipPos);
            }
        }
    }
}
