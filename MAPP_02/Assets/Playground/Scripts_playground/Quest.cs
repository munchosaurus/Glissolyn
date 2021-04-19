using UnityEngine;

public abstract class Quest
{
    protected static int QUEST_ID_COUNTER = 0; // Static variable, its shared between all Quest-objects to keep track of how many quests have been assigned.
    protected string questTitle;
    protected string questText;
    protected int questID;
    
    public Quest(string questTitle, string questText)
    {
        this.questTitle = questTitle;
        this.questText = questText;
        this.questID = QUEST_ID_COUNTER;
        QUEST_ID_COUNTER++; // Increase QUEST_ID_COUNTER by 1 to make sure the next quest that is created has an ID that is 1 higher than this quest.
    }

    // Return the questTitle-string
    public string GetQuestTitle()
    {
        return questTitle;
    }

    // Return the questText-string
    public string GetQuestText()
    {
        return questText;
    }

    // Return the questID as an integer.
    public int GetQuestID()
    {
        return questID;
    }
}
