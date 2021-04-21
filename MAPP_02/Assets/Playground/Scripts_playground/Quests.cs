using System.Collections.Generic;

public static class Quests
{
    private static Dictionary<int, Quest> allQuests = new Dictionary<int, Quest>();

    public static void Initialize()
    {
        // Add all quests here with allQuests.add(<the quest ID>, new <the quest>)
    }

    public static Quest GetQuest(int id)
    {
        return allQuests[id]; // Returns the Ability with ID id from allAbilities;
    }
}
