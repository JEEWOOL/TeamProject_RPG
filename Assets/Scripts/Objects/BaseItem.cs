using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;

namespace HOGUS.Scripts.Object.Item
{
    [CreateAssetMenu(fileName ="New BasicItem", menuName = "Scriptable Item Asset/Basic Item")]
    public class BaseItem : ScriptableObject
    {
        [Header("������ ����")]
        public ItemQuality quality;

        [Header("������ ��͵�")]
        public ItemRarity rarity;

        [Header("������ �̸�")]
        public string itemName;

        [Header("������ ����")]
        public string itemDescription;

        [Header("������ ũ��")]
        public int itemWidth;
        public int itemHeight;

        protected BaseItem(BaseItem item)
        {
            quality = item.quality;
            rarity = item.rarity;
            itemName = item.itemName;
            itemDescription = item.itemDescription;
            itemWidth = item.itemWidth;
            itemHeight = item.itemHeight;
        }
    }
}
