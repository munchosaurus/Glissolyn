using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest
{
    private static int QUEST_ID_COUNTER = 0;
    private string questTitle;
    private string questText;
    private int questID;
    
    public Quest(string questTitle, string questText)
    {
        this.questTitle = questTitle;
        this.questText = questText;
        this.questID = QUEST_ID_COUNTER;
        QUEST_ID_COUNTER++;
    }

    public string GetQuestTitle()
    {
        return questTitle;
    }

    public string GetQuestText()
    {
        return questText;
    }

    public int GetQuestID()
    {
        return questID;
    }
}
