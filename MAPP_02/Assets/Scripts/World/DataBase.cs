using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] private List<Quest> quests;
    [SerializeField] private List<NPC_Info> npcs;
    [SerializeField] private List<Enemy_Info> enemies;
    [SerializeField] private List<AudioClip> music;

    private int currentAudioID;

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

    public AudioClip GetMUsicByID(int id)
    {
        return music[id];
    }

    public void SetCurrentAudioID(int id)
    {
        currentAudioID = id;
    }

    public int GetCurrentAudioID()
    {
        return currentAudioID;
    }

    public void SaveGame()
    {
        try
        {
            FileInfo f = new FileInfo(Application.persistentDataPath + "/save.txt");
            if (f.Exists)
            {
                f.Delete();
            }
            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt")) {
                foreach (Quest quest in quests)
                {
                    writer.Write("q." + quests.IndexOf(quest) + ".");
                    int[] values = quest.GetSaveValues();
                    for (int i = 0; i < values.Length; i++)
                    {
                        writer.Write(values[i] + ".");
                    }
                    writer.WriteLine();
                }

                foreach (NPC_Info npc in npcs)
                {
                    writer.Write("n." + npcs.IndexOf(npc) + ".");
                    int[] values = npc.GetSaveValues();
                    for (int i = 0; i < values.Length; i++)
                    {
                        writer.Write(values[i] + ".");
                    }
                    writer.WriteLine();
                }

                foreach (Enemy_Info enemy in enemies)
                {
                    writer.Write("e." + enemies.IndexOf(enemy) + ".");
                    int[] values = enemy.GetSaveValues();
                    for (int i = 0; i < values.Length; i++)
                    {
                        writer.Write(values[i] + ".");
                    }
                    writer.WriteLine();
                }

                writer.Write("qcs.");
                foreach (int i in Game_Controller.GetSaveValues())
                {
                    writer.Write(i + ".");
                }
                writer.WriteLine();

                writer.Write($"p.{Game_Controller.GetPlayerInfo().GetName()}.");
                int[] pValues = Game_Controller.GetPlayerInfo().GetSaveValues();
                for (int i = 0; i < pValues.Length; i++)
                {
                    writer.Write(pValues[i] + ".");
                }
                writer.WriteLine();

                writer.WriteLine($"m.{currentAudioID}");
                PlayerPrefs.Save();
            }
        }catch(IOException e)
        {
            Debug.Log("IOException:\n" + e.Message);
        }
    }

    public void LoadGame()
    {
        try
        {
            Game_Controller.SetPause(true);
            Game_Controller.GetPlayerInfo().gameObject.SetActive(false);
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt")) {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split('.');
                    if (split[0] == "n")
                    {
                        Int32.TryParse(split[1], out int id);
                        int[] values = new int[split.Length - 2];
                        for (int i = 0; i < values.Length; i++)
                        {
                            Int32.TryParse(split[i + 2], out values[i]);
                        }
                        GetNpcByID(id).Init(values);
                    }
                    else if (split[0] == "q")
                    {
                        int[] values = new int[split.Length - 2];
                        Int32.TryParse(split[1], out int id);
                        for (int i = 0; i < values.Length; i++)
                        {
                            Int32.TryParse(split[i + 2], out values[i]);
                        }
                        GetQuestByID(id).Init(values);
                    }
                    else if (split[0] == "e")
                    {
                        Int32.TryParse(split[1], out int id);
                        int[] values = new int[split.Length - 2];
                        for (int i = 0; i < values.Length; i++)
                        {
                            Int32.TryParse(split[i + 2], out values[i]);
                        }
                        GetEnemyByID(id).Init(values);
                    }
                    else if (split[0] == "qcs")
                    {
                        int[] values = new int[split.Length - 1];
                        for (int i = 0; i < values.Length; i++)
                        {
                            Int32.TryParse(split[i + 1], out values[i]);
                        }
                        Game_Controller.Init(values);
                    }
                    else if (split[0] == "p")
                    {
                        string name = split[1];
                        int[] values = new int[split.Length - 2];
                        for (int i = 0; i < values.Length; i++)
                        {
                            Int32.TryParse(split[i + 2], out values[i]);
                        }
                        Game_Controller.GetPlayerInfo().Init(name, values);
                    }
                    else if (split[0] == "m")
                    {
                        Int32.TryParse(split[1], out int musicID);
                        currentAudioID = musicID;
                        Game_Controller.GetPlayerInfo().gameObject.SetActive(true);
                        Game_Controller.GetPlayerInfo().ChangeMusic(musicID);
                    }
                }
            }
            Game_Controller.SetPause(false);
        }catch(IOException e)
        {
            Debug.Log("IOexception:\n" + e.Message);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.Save();
        }
    }
}