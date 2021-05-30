using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_QuestGiver_Info : NPC_Info
{
    [SerializeField] private Quest questToGive;
    [SerializeField] private GameObject hasQuestIcon;

    private void Start()
    {
        if (questToGive.IsCompleted() || Game_Controller.GetQuestLog().HasQuest(questToGive))
        {
            hasQuestIcon.SetActive(false);
        }
        questToGive.SetWhoGaveQuest(this);
    }

    override
    public void Init(int[] loadValues)
    {
        while(questToGive.IsCompleted() && questToGive.GetNextQuestInChain() != null)
        {
            questToGive = questToGive.GetNextQuestInChain();
        }
        questToGive.SetWhoGaveQuest(this);
        base.Init(loadValues);
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
            hasQuestIcon.SetActive(false);
        }
        else if (questToGive.CanBeCompleted())
        {
            dialogue = questToGive.GetQuestCompletionDialogue();
            Game_Controller.GetQuestLog().RemoveQuest(questToGive.GetQuestID());
            Quest tempQuest = questToGive;

            if (questToGive.GetNextQuestInChain() != null)
            {
                questToGive = questToGive.GetNextQuestInChain();
                questToGive.SetWhoGaveQuest(this);
                Game_Controller.GetQuestLog().AddQuest(questToGive);

                var moreDialogue = questToGive.GetQuestStartDialogue();
                var tempArray = new string[dialogue.Length + moreDialogue.Length];
                dialogue.CopyTo(tempArray, 0);
                moreDialogue.CopyTo(tempArray, dialogue.Length);
                dialogue = tempArray;
            }

            tempQuest.CompleteQuest();
        }
        else
        {
            dialogue = questToGive.GetQuestActiveDialogue();
        }
        if (gameObject.name.Contains("Old Man"))
        {
            Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);
            Game_Controller.GetPlayerInfo().SetRespawnPos(temp);
        }

        if (CompareTag("Quest"))
        {
            Game_Controller.GetQuestLog().UpdateQuestAfterInteraction(gameObject.name);
        }

        base.Interact();
    }

    public void SetQuestToGive(Quest quest)
    {
        questToGive = quest;
    }
}
