using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_QuestGiver_Info : NPC_Info
{
    [SerializeField] private Quest questToGive;
    [TextArea] [SerializeField] private string[] questActiveDialogue;
    [TextArea] [SerializeField] private string[] questCompletionDialogue;
    [TextArea] [SerializeField] private string[] questCompletedDialogue;

    private bool questIsCompleted;

    private void Start()
    {
        questToGive.Init();
    }

    override
    public void Interact()
    {
        if (questIsCompleted)
        {
            dialogue = questCompletedDialogue;
        }
        else if (!questToGive.IsCompleted() && !Game_Controller.GetQuestLog().HasQuest(questToGive))
        {
            Game_Controller.GetQuestLog().AddQuest(questToGive);
            Game_Controller.GetQuestLog().SetCurrentOpenQuestButton(questToGive.GetQuestButton());
        }
        else if (questToGive.CompleteQuest())
        {
            dialogue = questCompletionDialogue;
            questIsCompleted = true;
        }
        else
        {
            dialogue = questActiveDialogue;
        }
        base.Interact();
    }
}
