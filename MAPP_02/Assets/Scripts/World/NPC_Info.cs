using UnityEngine;

public class NPC_Info : Character_Info
{
    [SerializeField] protected Sprite npcDialogueSprite;
    [TextArea] [SerializeField] protected string[] dialogue;
    [TextArea] [SerializeField] protected string[][] alternativeDialogue;

    public virtual void Interact()
    {
        if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove))
        {
            npcmove.TurnToPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().GetFacing());
        }
        Game_Controller.GetDialogueBox().UpdateDialogue(this);

        if (CompareTag("Respawn"))
        {
            Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1, gameObject.transform.position.z);
   
            Game_Controller.GetPlayerInfo().SetRespawnPos(temp);
        }
    }

    public string[] GetDialogue()
    {
        return dialogue;
    }

    public Sprite GetDialogueSprite()
    {
        return npcDialogueSprite;
    }

    public void ChangeDialogue(int index) 
    {
        dialogue = alternativeDialogue[index];
    }
}
