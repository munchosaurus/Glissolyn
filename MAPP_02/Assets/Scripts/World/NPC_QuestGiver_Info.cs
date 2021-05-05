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
            dialogue = questToGive.GetQuestStartDialogue();
            Game_Controller.GetQuestLog().AddQuest(questToGive);
            Game_Controller.GetQuestLog().SetCurrentOpenQuestButton(questToGive.GetQuestButton());
        }
        else if (questToGive.CompleteQuest())
        {
            dialogue = questToGive.GetQuestCompletionDialogue();

            if (questToGive.GetNextQuestInChain() != null)
            {
                questToGive = questToGive.GetNextQuestInChain();
                Game_Controller.GetQuestLog().AddQuest(questToGive);
                Game_Controller.GetQuestLog().SetCurrentOpenQuestButton(questToGive.GetQuestButton());

                var moreDialogue = questToGive.GetQuestStartDialogue();
                var tempArray = new string[dialogue.Length + moreDialogue.Length];
                dialogue.CopyTo(tempArray, 0);
                moreDialogue.CopyTo(tempArray, dialogue.Length);
                dialogue = tempArray;
            }
        }
        else
        {
            dialogue = questToGive.GetQuestActiveDialogue();
        }

        base.Interact();

        
    }
}
