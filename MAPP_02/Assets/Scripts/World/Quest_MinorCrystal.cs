using System;
using UnityEngine;

public class Quest_MinorCrystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] dialogueQuest;

    override
    public void Interact()
    {


        

        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            dialogue = dialogueQuest;
            
            GameObject.Find("Minor Crystal").SetActive(false);
        }

        base.Interact();
        

    }
}
