using UnityEngine;

public abstract class Quest : ScriptableObject
{
    [SerializeField] protected string questTitle;
    [TextArea][SerializeField] protected string questDescription;
    [SerializeField] protected int questID;
    protected bool isCompleted;
    protected QuestButton questButton;
    protected string questText;

    // Return the questTitle-string
    public string GetQuestTitle()
    {
        return questTitle;
    }

    // Return the questText-string
    public string GetQuestText()
    {
        BuildQuestText();
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

    public void SetButton(QuestButton qb)
    {
        questButton = qb;
    }

    protected virtual void BuildQuestText()
    {
        questText = questDescription;
    }

    public virtual void UpdateQuest()
    {
        questButton.UpdateQuestText(questText);
    }

    public virtual bool CompleteQuest()
    {
        return isCompleted;
    }

    public abstract QuestType GetQuestType();
}

public enum QuestType
{
    QuestTypeError,
    KILL_QUEST
}
