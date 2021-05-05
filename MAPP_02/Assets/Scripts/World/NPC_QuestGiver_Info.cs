using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_QuestGiver_Info : NPC_Info
{
    [SerializeField] private Quest questToGive;

    private void Start()
    {
        questToGive.Init();
    }

    override
    public void Interact()
    {
        if (questToGive.IsCompleted())
        {
            dialogue = questToGive.GetQuestCompletedDialogue();
        }
        else if (!questToGive.IsCompleted() && !Game_Controller.GetQuestLog().HasQuest(questToGive))
        {
            Game_Controller.GetQuestLog().AddQuest(questToGive);
            Game_Controller.GetQuestLog().SetCurrentOpenQuestButton(questToGive.GetQuestButton());
        }
        else if (questToGive.CompleteQuest())
        {
            dialogue = questToGive.GetQuestCompletionDialogue();
        }
        else
        {
            dialogue = questToGive.GetQuestActiveDialogue();
        }

        base.Interact();

        if (questToGive.IsCompleted() && questToGive.GetNextQuestInChain() != null)
        {
            questToGive = questToGive.GetNextQuestInChain();
            Interact();
        }
    }
}
