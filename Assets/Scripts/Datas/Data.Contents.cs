using HOGUS.Scripts.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;
using HOGUS.Scripts.Object.Item;

// Reference by : https://velog.io/@starkshn/Data-Manager

namespace HOGUS.Scripts.Data
{
    #region PlayerData
    [Serializable]
    public class SavePlayerData
    {
        // ��� �÷��̾� Ŭ���� ��ü�� ������ �޾ƿ;���
        public string PlayerName { get; set; }
        public int Stage { get; set; }
        public int LastHP { get; set; }
        public int LastMP { get; set; }
        // �÷��̾� �κ��丮, �� ������, ����Ʈ ��Ȳ � ����
    }

    [Serializable]
    public class PlayerData : ILoader<string, SavePlayerData>
    {
        public List<SavePlayerData> savePlayerDatas = new();

        public Dictionary<string, SavePlayerData> MakeDict()
        {
            Dictionary<string, SavePlayerData> dict = new();
            foreach (SavePlayerData playerData in savePlayerDatas)           // ����Ʈ���� Dictionary�� �ű�
            {
                dict.Add(playerData.PlayerName, playerData);           // ID�� Key�� ���
            }
            return dict;
        }
    }
    #endregion

    #region ItemData
    [Serializable]
    public class Item : ScriptableObject
    {
        public int id;
        public ItemType type;
        //public string name;
        public Sprite sprite;
        public string desc;

        public bool Use()
        {
            return false;
        }
    }

    [Serializable]
    public class ItemData : ILoader<int, BaseItem>
    {
        public List<BaseItem> items = new();            // json ���Ͽ��� ��� ����Ʈ

        public Dictionary<int, BaseItem> MakeDict()
        {
            Dictionary<int, BaseItem> dict = new();
            foreach (BaseItem item in items)           // ����Ʈ���� Dictionary�� �ű�
            {
                dict.Add(item.id, item);           // ID�� Key�� ���
            }
            return dict;
        }
    }
    #endregion

}