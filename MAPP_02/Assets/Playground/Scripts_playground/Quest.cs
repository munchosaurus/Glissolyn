using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
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
=======
public abstract class Quest : ScriptableObject
{
    [SerializeField] protected string questTitle;
    [TextArea] [SerializeField] protected string questDescription;
    [SerializeField] protected int questID;
    [SerializeField] protected int experienceReward;
    [SerializeField] protected QuestClearState questClearState;
    protected bool isCompleted = false;
    protected QuestButton questButton;
    protected string questText;

    public virtual void Init()
    {
        isCompleted = false;
>>>>>>> Main
    }

    public string GetQuestTitle()
    {
        return questTitle;
    }

    public string GetQuestText()
    {
        BuildQuestText();
        return questText;
    }

    public int GetQuestID()
    {
        return questID;
    }
<<<<<<< HEAD
=======

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
        }
        return isCompleted;
    }

    public abstract QuestType GetQuestType();
}

public enum QuestType
{
    QuestTypeError,
    KILL_QUEST
}

public enum QuestClearState
{
    NONE,
    OPEN_VILLAGE_EXIT
>>>>>>> Main
}
