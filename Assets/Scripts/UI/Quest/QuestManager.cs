using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("���� ���� ����� ��ȭ�ϱ�.", new int[] { 1000 }));
        questList.Add(20, new QuestData("���� 0 / 5 ���", new int[] { 1000 }));
        questList.Add(30, new QuestData("���� �̿� �ٽ� ��ȭ�ϱ�", new int[] { 1000 }));
        questList.Add(40, new QuestData("���� ����� �ѷ��� ���� 0 / 10 ���", new int[] { 2000 }));
        questList.Add(50, new QuestData("���� ��� �����ϱ�.", new int[] { 2000 }));
        questList.Add(60, new QuestData("���� ����� ��ȭ�ϱ�.", new int[] { 3000 }));
        questList.Add(70, new QuestData("���� ����ϱ� 0 / 1", new int[] { 4000 }));
        questList.Add(80, new QuestData("Ȥ�� �� ���迡 ����ϱ�.", new int[] { 4000 }));
    }

    public int GetQuestTalkIndex(int _id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int _id)
    {
        // ���� ����Ʈ�� ����
        if (_id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        // ����Ʈ�� �����س��� npc��� ��ȭ�� �� ��������
        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //quest Name
        return questList[questId].questName;
    }

    public void AddQuestAction()
    {
        questActionIndex++;
    }


    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}
