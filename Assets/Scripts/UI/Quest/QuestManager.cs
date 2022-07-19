using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;
    public TextMeshProUGUI questText;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("���� ���� ����� ��ȭ�ϱ�.", new int[] { 1000 }));
        questList.Add(20, new QuestData("���� ��� �����ϱ�.", new int[] { 2000 }));
        questList.Add(30, new QuestData("���� ����� ��ȭ�ϱ�.", new int[] { 3000 }));
    }

    public int GetQuestTalkIndex(int _id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int _id)
    {
        // ���� ����Ʈ�� ����
        if(_id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        // ����Ʈ�� �����س��� npc��� ��ȭ�� �� ��������
        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //quest Name
        questText.text = questList[questId].questName;
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        //quest Name
        questText.text = questList[questId].questName;
        return questList[questId].questName;
    }

    private void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}
