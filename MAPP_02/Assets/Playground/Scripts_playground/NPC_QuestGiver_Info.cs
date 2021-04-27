using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_QuestGiver_Info : NPC_Info
{
    [SerializeField] private Quest questToGive;
    [TextArea][SerializeField] private string[] questActiveDialogue;
    [TextArea][SerializeField] private string[] questCompletedDialogue;

    override
    public void Interact()
    {
        if (!questToGive.IsCompleted() && !Game_Controller.GetQuestLog().HasQuest(questToGive))
        {
            Game_Controller.GetQuestLog().AddQuest(questToGive);
        }
        else if (questToGive.CompleteQuest())
        {
            dialogue = questCompletedDialogue;
        }
        else
        {
            dialogue = questActiveDialogue;
        }
        base.Interact();
        
    }
}
