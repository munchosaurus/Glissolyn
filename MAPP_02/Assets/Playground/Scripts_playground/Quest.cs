using UnityEngine;

public abstract class Quest
{
    protected string questTitle;
    protected string questText;
    protected int questID;
    protected bool isCompleted;

    public Quest(string questTitle, string questText, int id)
    {
        this.questTitle = questTitle;
        this.questText = questText;
        this.questID = id;
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

    public bool IsCompleted()
    {
        return isCompleted;
    }

    public virtual void UpdateQuest()
    {

    }

    public virtual bool CompleteQuest()
    {
        return isCompleted;
    }
}
