using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_KillQuest : Quest
{
    private int amountToKill;
    private int killed;

    public Quest_KillQuest(string questTitle, string questText, int id, string enemyToKill, int amountToKill) : base(questTitle, questText, id)
    {
        this.amountToKill = amountToKill;
        this.questText = this.questText + "\n\n" +  enemyToKill + " killed: " + killed + "/" + amountToKill;
    }

    override
    public void UpdateQuest()
    {
        if(killed < amountToKill)
        {
            killed++;
        }
    }
    
    override
    public bool CompleteQuest()
    {
        if(killed == amountToKill)
        {
            isCompleted = true;
            Game_Controller.GetQuestLog().RemoveQuest(questID);
        }

        return isCompleted;
    }
}
