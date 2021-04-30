using UnityEngine;

public class NPC_Info : Character_Info
{
    [SerializeField] protected Sprite npcDialogueSprite;
    [TextArea] [SerializeField] protected string[] dialogue;

    // A dummy method to give the child-classes a method to override that can still be called from a NPC_Info-object.
    public virtual void Interact()
    {
        if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove))
        {
            npcmove.TurnToPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().GetFacing());
        }
        Game_Controller.GetDialogueBox().UpdateDialogue(this);
    }

    public string[] GetDialogue()
    {
        return dialogue;
    }

    public Sprite GetDialogueSprite()
    {
        return npcDialogueSprite;
    }
}
