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
        using (StreamWriter writer = new StreamWriter(File.Open(Application.dataPath + "/save.txt", FileMode.Create))) {
            foreach (Quest quest in quests)
            {
                writer.Write("q" + quests.IndexOf(quest) + ".");
                int[] values = quest.GetSaveValues();
                for(int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + ".");
                }
                writer.WriteLine();
            }

            foreach (NPC_Info npc in npcs)
            {
                writer.Write("n" + npcs.IndexOf(npc) + ".");
                int[] values = npc.GetSaveValues();
                for(int i = 0; i < values.Length; i++)
                {
                    writer.Write(values[i] + ".");
                }
                writer.WriteLine();
            }

            foreach (Enemy_Info enemy in enemies)
            {
                writer.Write("e" + enemies.IndexOf(enemy) + ".");
                int[] values = enemy.GetSaveValues();
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
        }
    }

    public void LoadGame()
    {
        using (StreamReader reader = new StreamReader(File.Open(Application.dataPath + "/save.txt", FileMode.Open)))
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
        }
    }
}