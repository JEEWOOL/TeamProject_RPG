using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Quest/QuestDataBase")]
public class QuestDataBase : ScriptableObject
{
    [SerializeField]
    private List<Quest> quests;

    public IReadOnlyList<Quest> Quests => quests;

    // codeName�� ���ؼ� ����Ʈ ã�ƿ���
    public Quest FindQuestBy(string codeName) => quests.FirstOrDefault(x => x.CodeName == codeName);


#if UNITY_EDITOR

    [ContextMenu("FindQuests")]
    private void FindQuest()
    {
        FindQuestBy<Quest>();
    }

    [ContextMenu("FindAchievements")]
    private void FindAchievement()
    {
        FindQuestBy<Achievement>();
    }

    // ����Ʈ�� ã�ƿ��� Util
    // ���׸� �Լ��� ������ ���� �ڵ�� ����Ʈ�� ������ ���� ã�� ���ؼ�
    private void FindQuestBy<T>() where T : Quest
    {
        quests = new List<Quest>();

        // FindAssets�� Assets�������� Filter�� �´� ������ GUID�� �������� �Լ�
        // GUID�� ����Ƽ�� ������ �����ϱ� ���� ���������� ����ϴ� ID
        string[] guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
        foreach(var guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var quest = AssetDatabase.LoadAssetAtPath<T>(assetPath);

            // GetType���ִ� ������ ���࿡ T�� ����Ʈ Ŭ������� AchievementŬ������ ����Ʈ Ŭ������ ��� �ް� �ֱ� ������
            // �� ã�ƿ� ���� �־ �ٽ� �ѹ� �˻����ش�
            if (quest.GetType() == typeof(T))
            {
                quests.Add(quest);
            }

            // SetDirty�� QuestDataBase��ü�� ���� Serialize������ ��ȭ�� ������ �ݿ��϶�� �Լ�
            EditorUtility.SetDirty(this);

            // ���� ����
            AssetDatabase.SaveAssets();
        }
    }
#endif
}
