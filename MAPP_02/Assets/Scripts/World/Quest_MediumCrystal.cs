using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest_MediumCrystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] dialogueQuest;
    [SerializeField] private GameObject objectOneToDestroy;
    [SerializeField] private GameObject objectTwoToDestroy;


    override
    public void Interact()
    {

        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            dialogue = dialogueQuest;
            objectOneToDestroy.SetActive(false);
            objectTwoToDestroy.SetActive(false);
            gameObject.SetActive(false);
        }
        base.Interact();

    }
}
