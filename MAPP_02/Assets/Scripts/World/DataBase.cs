using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] private List<QuestEntry> quests;

    public void ResetQuests()
    {
        foreach(QuestEntry quest in quests)
        {
            quest.GetQuest().Init();
        }
    }

    public Quest GetQuestByID(int id)
    {
        return quests.Find(i => i.GetId() == id).GetQuest();
    }
}

[System.Serializable]
public class QuestEntry
{
    [SerializeField] int id;
    [SerializeField] Quest quest;

    public int GetId()
    {
        return id;
    }

    public Quest GetQuest()
    {
        return quest;
    }
}
