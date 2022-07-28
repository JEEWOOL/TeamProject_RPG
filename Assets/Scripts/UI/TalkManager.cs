using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public UIManager uIManager;
    public QuestManager questManager;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //Talk Data
        //NPC OldMan: 1000, NPC MAN: 2000, NPC Female: 3000
        // npc id�� �޾Ƽ� �ش� npc�� ��� ���
        talkData.Add(1000, new string[] { "����ð�, ��翩.." });
        talkData.Add(2000, new string[] { "�����ּ���.. ����.." });
        talkData.Add(3000, new string[] { "������!" });

        // ���� ��� ����Ʈ
        talkData.Add(10 + 1000, new string[] { "����ð�, ��翩..", "���غ��̴±�.", "�� ��Ź �ϳ� ����ְڴ°�?", "��ó�� ���� 2������ ����ְ�" });
        talkData.Add(21 + 1000, new string[] { "2������ ��Ź�ϳ�"});

        talkData.Add(30 + 1000, new string[] { "���ٳ�. ���� �ް� ��ġ������..", "Ȥ�� �����ٸ� ����������� �������� �� �ְڳ�?" });

        // ���� ���� ����Ʈ
        talkData.Add(40 + 1000, new string[] { "���� ����� ���� ����� �ٷ� �� �� ������ �ֳ�." });
        talkData.Add(50 + 2000, new string[] { "�����մϴ�!", "���� �����մϴ�!", "������ ���� ������ �� �� ���� ����� �ֽ��ϴ�.", "��Ź�帳�ϴ�." });

        // ���� ���� ����Ʈ
        talkData.Add(60 + 3000, new string[] { "�ʵ� ������ ������ �� �ž�?", "Ư���� ������ ���� �纸���ٰ�" });
    }

    public string GetTalk(int _id, int _talkIndex)
    {
        if(!talkData.ContainsKey(_id))
        {
            if(!talkData.ContainsKey(_id - _id %10))
            {
                // ����Ʈ �� ó�� ��縶�� ���ٸ� �⺻ ��縸 ���
               return GetTalk(_id - _id %100, _talkIndex);  
            }
            else
            {
                // �ش� ����Ʈ ���� ���� ��簡 ���� ��
                // ����Ʈ �� ó�� ��縦 �����´�.
                return GetTalk(_id - _id % 10, _talkIndex);
            }
        }
        if(_talkIndex == talkData[_id].Length)
        {
            return null;
        }
        else
        {
            return talkData[_id][_talkIndex];
        }
    }
}
