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
        public Tester tester;
        private GameObject weaponGO;

        // ��� ������ ���� ���¸� ��Ÿ���� ��ųʸ�
        public Dictionary<EquipPart, EquipmentItem> dictEquipmets = new();

        /// <summary>
        /// �� ������ ���� �Լ�
        /// </summary>
        public void DoEquip(EquipPart part, ArmorItem armorItem)
        {
            // ���� �ش� ������ �����ϰ� �ִٸ� ���� ���� �� ��ȯ
            if (dictEquipmets.ContainsKey(part))
            {
                dictEquipmets.Remove(part);
            }
            else
            {
                tester.defense += armorItem.defense;
            }
            dictEquipmets.Add(part, armorItem);

        }

        /// <summary>
        /// ���� ������ ���� �Լ�
        /// </summary>
        public void DoEquip(EquipPart part, WeaponItem weaponItem)
        {
            if (dictEquipmets.ContainsKey(part))
            {
                dictEquipmets.Remove(part);
                Destroy(weaponGO);
            }
            else
            {
                tester.minDamage += weaponItem.minDamage;
                tester.maxDamage += weaponItem.maxDamage;
                tester.attackSpeed += weaponItem.attackSpeed;
            }
            dictEquipmets.Add(part, weaponItem);

            if (part == EquipPart.WEAPON)
            {
                WeaponItem weaponPart = (WeaponItem)dictEquipmets[part];
                AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(weaponPart.refAddress);
                handle.Completed += AsyncOperationHandle_Complete;
            }
        }

        /// <summary>
        /// �Էµ� ��Ʈ�� ��� ����
        /// </summary>
        public void DoUnequip(EquipPart part)
        {
            if(dictEquipmets.ContainsKey(part))
            {
                dictEquipmets.Remove(part);
            }

            if(part == EquipPart.WEAPON)
            {
                if(weaponGO != null)
                {
                    Destroy(weaponGO);
                }
            }
        }

        private void AsyncOperationHandle_Complete(AsyncOperationHandle<GameObject> handle)
        {
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                weaponGO = Instantiate(handle.Result, tester.weaponEquipPos);
            }
        }
    }
}
