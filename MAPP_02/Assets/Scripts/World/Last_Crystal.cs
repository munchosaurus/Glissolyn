using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Crystal : NPC_Info
{

    private int interactCounter;
    [SerializeField] GameObject witch;
    [SerializeField] protected Quest quest;
    [TextArea] [SerializeField] protected string[] questDialogue;
    [SerializeField] GameObject player;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        witch.SetActive(false);
    }

    


    override
    public void Interact()
    {

        if (Game_Controller.GetQuestLog().HasQuest(quest))
        {


            if (interactCounter == 0)
            {
                Vector3 distanceDifference = new Vector3(1, 0);
                if (player.transform.position.x < gameObject.transform.position.x)
                {
                    witch.transform.position = player.transform.position - distanceDifference;
                    witch.GetComponent<Enemy_rotate>().SetOnlyFace(Facing.RIGHT);
                }
                else
                {
                    witch.transform.position = player.transform.position + distanceDifference;
                    witch.GetComponent<Enemy_rotate>().SetOnlyFace(Facing.LEFT);
                }
                interactCounter++;
                witch.SetActive(true);
            }
            else if(interactCounter!=0 && witch.GetComponent<BoxCollider2D>().enabled.Equals(false)){
                dialogue = questDialogue;
                gameObject.tag = "Quest";
                gameObject.SetActive(false);
                Game_Controller.UpdateWorldToQuestClearState(QuestClearState.ELDHAM_PURIFIED);
            }
        }
        base.Interact();

    }

   


    
}
