using System.Collections.Generic;
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
    public void Init(int[] loadValues)
    {
        hasBeenInteractedWith = loadValues[2] == 1;
        BuildQuestText();
        base.Init(loadValues);
    }

    override
    public int[] GetSaveValues()
    {
        saveValues = new int[3];
        saveValues[2] = hasBeenInteractedWith ? 1 : 0;
        return base.GetSaveValues();
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

    public bool HasBeenInteractedWith()
    {
        return hasBeenInteractedWith;
    }

    override
    public bool CanBeCompleted()
    {
        if (hasBeenInteractedWith)
        {
            isCompleted = true;
        }
        return isCompleted;
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
