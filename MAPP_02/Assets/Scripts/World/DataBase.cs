using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] private List<Quest> quests;
    [SerializeField] private List<NPC_Info> npcs;
    [SerializeField] private List<Enemy_Info> enemies;

    public void ResetQuests()
    {
        foreach(Quest quest in quests)
        {
            quest.Init();
        }
    }

    public Quest GetQuestByID(int id)
    {
        return quests[id];
    }

    public NPC_Info GetNpcByID(int id)
    {
        return npcs[id];
    }

    public Enemy_Info GetEnemyByID(int id)
    {
        return enemies[id];
    }

    public void SaveGame()
    {
        /*using (StreamWriter writer = new StreamWriter(File.Open(Application.dataPath + "/save.txt", FileMode.Create))) {
            foreach (QuestEntry questEntry in quests)
            {
                writer.Write("q" + questEntry.GetId() + ".");
                int[] values = questEntry.GetQuest().GetSaveValues();
                for(int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + ".");
                }
                writer.WriteLine();
            }

            foreach (NPCEntry npcEntry in npcs)
            {
                writer.Write("n" + npcEntry.GetId() + ".");
                int[] values = npcEntry.GetNpcInfo().GetSaveValues();
                for(int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + ".");
                }
                writer.WriteLine();
            }

            foreach (EnemyEntry eEntry in enemies)
            {
                writer.Write("e" + eEntry.GetId() + ".");
                int[] values = eEntry.GetEnemyInfo().GetSaveValues();
                for (int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + ".");
                }
                writer.WriteLine();
            }

            writer.Write($"p{Game_Controller.GetPlayerInfo().GetName()}.");
            int[] pValues = Game_Controller.GetPlayerInfo().GetSaveValues();
            for(int i = 0; i < pValues.Length; i++)
            {
                writer.Write(pValues[i] + ".");
            }
            writer.WriteLine();
        }*/
    }

    public void LoadGame()
    {
        /*using (StreamReader reader = new StreamReader(File.Open(Application.dataPath + "/save.txt", FileMode.Open)))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (line[0] == 'q')
                {
                    string[] split = line.Split('.');
                    int id;
                    Int32.TryParse(split[0].Substring(1), out id);
                    int[] values = new int[split.Length - 1];
                    for (int i = 0; i < values.Length; i++)
                    {
                        Int32.TryParse(split[i+1], out values[i]);
                    }
                    GetQuestByID(id).Init(values);
                }
                else if(line[0] == 'n')
                {
                    string[] split = line.Split('.');
                    int id;
                    Int32.TryParse(split[0].Substring(1), out id);
                    int[] values = new int[split.Length - 1];
                    for (int i = 0; i < values.Length; i++)
                    {
                        Int32.TryParse(split[i + 1], out values[i]);
                    }
                    GetNpcByID(id).Init(values);
                }
                else if (line[0] == 'e')
                {
                    string[] split = line.Split('.');
                    int id;
                    Int32.TryParse(split[0].Substring(1), out id);
                    int[] values = new int[split.Length - 1];
                    for (int i = 0; i < values.Length; i++)
                    {
                        Int32.TryParse(split[i + 1], out values[i]);
                    }
                    GetEnemyByID(id).Init(values);
                }
                else if (line[0] == 'p')
                {
                    string[] split = line.Split('.');
                    string name = split[0].Substring(1);
                    int[] values = new int[split.Length - 1];
                    for (int i = 0; i < values.Length; i++)
                    {
                        Int32.TryParse(split[i + 1], out values[i]);
                    }
                    Game_Controller.GetPlayerInfo().Init(name, values);
                }
            }
        }*/
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

[System.Serializable]
public class NPCEntry
{
    [SerializeField] int id;
    [SerializeField] NPC_Info npcInfo;

    public int GetId()
    {
        return id;
    }

    public NPC_Info GetNpcInfo()
    {
        return npcInfo;
    }
}

[System.Serializable]
public class EnemyEntry
{
    [SerializeField] int id;
    [SerializeField] Enemy_Info eInfo;

    public int GetId()
    {
        return id;
    }
    
    public Enemy_Info GetEnemyInfo()
    {
        return eInfo;
    }
}
