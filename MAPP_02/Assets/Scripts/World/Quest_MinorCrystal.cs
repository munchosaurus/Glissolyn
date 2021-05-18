using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest_MinorCrystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] dialogueQuest;
    [SerializeField] GameObject objectToActivate;

    override
    public void Interact()
    {
        
        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            dialogue = dialogueQuest;
        }
        base.Interact();
        if (Game_Controller.GetQuestLog().HasQuest(quest)) 
        {
            objectToActivate.SetActive(true);
            GameObject.Find("Minor Crystal").SetActive(false);
        }
    }
}
