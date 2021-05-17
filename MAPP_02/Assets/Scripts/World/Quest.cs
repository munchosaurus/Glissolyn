using UnityEngine;

public abstract class Quest : ScriptableObject
{
    [SerializeField] protected string questTitle;
    [TextArea] [SerializeField] protected string questDescription;
    [SerializeField] protected int questID;
    [SerializeField] protected int experienceReward;
    [SerializeField] protected QuestClearState questClearState;
    [SerializeField] protected Quest nextQuestInChain;

    [TextArea] [SerializeField] private string[] questStartDialogue;
    [TextArea] [SerializeField] private string[] questActiveDialogue;
    [TextArea] [SerializeField] private string[] questCompletionDialogue;
    [TextArea] [SerializeField] private string[] questCompletedDialogue;

    protected bool isCompleted = false;
    protected QuestButton questButton;
    protected string questText;

    public virtual void Init()
    {
        isCompleted = false;
    }

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

    public QuestButton GetQuestButton()
    {
        return questButton;
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
        if (isCompleted)
        {
            Game_Controller.UpdateWorldToQuestClearState(questClearState);
            Game_Controller.GetPlayerInfo().ModifyExperience(experienceReward);
            Game_Controller.GetQuestLog().RemoveQuest(questID);
        }
        return isCompleted;
    }

    public virtual string[] GetQuestStartDialogue()
    {
        return questStartDialogue;
    }

    public virtual string[] GetQuestActiveDialogue()
    {
        return questActiveDialogue;
    }

    public virtual string[] GetQuestCompletionDialogue()
    {
        return questCompletionDialogue;
    }

    public virtual string[] GetQuestCompletedDialogue()
    {
        return questCompletedDialogue;
    }

    public virtual Quest GetNextQuestInChain()
    {
        return nextQuestInChain;
    }

    public abstract QuestType GetQuestType();
}

public enum QuestType
{
    QuestTypeError,
    KILL_QUEST,
    INTERACTION_QUEST
}

public enum QuestClearState
{
    NONE,
    OPEN_VILLAGE_EXIT
}
