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

        [Header("������ ũ��")]
        public int itemWidth;
        public int itemHeight;
    }
}
