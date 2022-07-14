using HOGUS.Scripts.Manager;
using System;
using System.Collections.Generic;

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
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sprite_path { get; set; }
        public string Desc { get; set; }
    }

    [Serializable]
    public class ItemData : ILoader<int, Item>
    {
        public List<Item> items = new();            // json ���Ͽ��� ��� ����Ʈ

        public Dictionary<int, Item> MakeDict()
        {
            Dictionary<int, Item> dict = new();
            foreach (Item item in items)           // ����Ʈ���� Dictionary�� �ű�
            {
                dict.Add(item.Id, item);           // ID�� Key�� ���
            }
            return dict;
        }
    }
    #endregion

}