using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Create new Interaction quest")]
public class Quest_InteractionQuest : Quest
{
    [SerializeField] private string objectToInteractWith;
    private string objectiveText;
    private bool hasBeenInteractedWith;

    override
    public void Init()
    {
        hasBeenInteractedWith = false;
        objectiveText = "";
        base.Init();
    }

    override
    public void UpdateQuest()
    {
        hasBeenInteractedWith = true;
        questButton.UpdateQuestText(GetQuestText());
    }

    override
    protected void BuildQuestText()
    {
        if (!hasBeenInteractedWith)
        {
            objectiveText = "You have not yet interacted with " + objectToInteractWith;

        }
        else {
            objectiveText = "You have interacted with " + objectToInteractWith;
        }
        questText = questDescription + "\n\n" + objectiveText;
    }

    override
    public bool CompleteQuest()
    {
        if (hasBeenInteractedWith)
        {
            isCompleted = true;
            Game_Controller.GetQuestLog().RemoveQuest(questID);
        }

        return base.CompleteQuest();
    }


    override
    public QuestType GetQuestType()
    {
        return QuestType.INTERACTION_QUEST;
    }

    public void CheckInteraction(string name) {
        
        if (objectToInteractWith.Equals(name)) {
            UpdateQuest();
        }
    }
}
