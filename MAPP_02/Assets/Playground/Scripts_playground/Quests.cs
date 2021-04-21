using System.Collections.Generic;

public static class Quests
{
    private static Dictionary<int, Quest> allQuests = new Dictionary<int, Quest>();

    public static void Initialize()
    {
        // Add all quests here with allQuests.add(<the quest ID>, new <the quest>)
        allQuests.Add(0, new Quest_KillQuest("First Quest", "This is your first quest. Kill a Zombie.", 0, "Zombie", 1));
    }

    public static Quest GetQuest(int id)
    {
        return allQuests[id]; // Returns the Ability with ID id from allAbilities;
    }
}
