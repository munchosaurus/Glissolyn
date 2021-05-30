using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Crystal : NPC_Info
{
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] questDialogue;

    override
    public void Interact()
    {

        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {
            if (!Game_Controller.HasQuestClearStateBeenRun(QuestClearState.SPAWN_WITCH))
            {
                Game_Controller.UpdateWorldToQuestClearState(QuestClearState.SPAWN_WITCH);
            }
            else if(!Game_Controller.HasQuestClearStateBeenRun(QuestClearState.ELDHAM_PURIFIED))
            {
                dialogue = questDialogue;
                gameObject.tag = "Quest";
                gameObject.SetActive(false);
                Game_Controller.UpdateWorldToQuestClearState(QuestClearState.ELDHAM_PURIFIED);
                base.Interact();
            }
        }
        

    }

   


    
}
