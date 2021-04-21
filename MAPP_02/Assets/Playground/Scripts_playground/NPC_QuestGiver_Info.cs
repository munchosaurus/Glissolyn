using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_QuestGiver_Info : NPC_Info
{
    [SerializeField] private int questIDToGive;
    [SerializeField] private string[] questActiveDialogue;
    [SerializeField] private string[] questCompletedDialogue;

    private bool questHasBeenGiven;


    override
    public void Interact()
    {
        if (!Quests.GetQuest(questIDToGive).IsCompleted() && !Game_Controller.GetQuestLog().HasQuest(questIDToGive))
        {
            Game_Controller.GetQuestLog().AddQuest(Quests.GetQuest(questIDToGive));
        }
        else if (Quests.GetQuest(questIDToGive).CompleteQuest())
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
