using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest_MinorCrystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] dialogueQuest;
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject objectBlocking;

    override
    public void Interact()
    {
        
        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            dialogue = dialogueQuest;
            objectToActivate.SetActive(true);
            objectBlocking.SetActive(false);
            gameObject.SetActive(false);
            //GameObject.Find("Minor Crystal").SetActive(false);
        }
        base.Interact();

    }
}
