using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest_MediumCrystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] dialogueQuest;

    override
    public void Interact()
    {

        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            dialogue = dialogueQuest;
            gameObject.SetActive(false);
        }
        base.Interact();

    }
}
