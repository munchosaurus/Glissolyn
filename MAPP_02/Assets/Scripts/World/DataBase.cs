using System;
using System.Collections.Generic;
using System.IO;
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

    public void SaveGame()
    {
        using (StreamWriter writer = new StreamWriter(File.Open(Application.dataPath + "/DontPeek/save.txt", FileMode.Create))) {
            foreach (QuestEntry questEntry in quests)
            {
                writer.Write("q" + questEntry.GetId() + ".");
                int[] values = questEntry.GetQuest().GetSaveValues();
                for(int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + "-");
                }
                writer.WriteLine();
            }
        }
    }

    public void LoadGame()
    {
        using (StreamReader reader = new StreamReader(File.Open(Application.dataPath + "/DontPeek/save.txt", FileMode.Open)))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                print(line);
                if (line[0] == 'q')
                {
                    string[] split = line.Split('.');
                    int id;
                    Int32.TryParse(split[0].Substring(1), out id);
                    string[] stringValues = split[1].Split('-');
                    int[] values = new int[stringValues.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        Int32.TryParse(stringValues[i], out values[i]);
                    }
                    GetQuestByID(id).Init(values);
                }
            }
        }
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
