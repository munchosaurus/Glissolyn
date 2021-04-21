using UnityEngine;

public class NPC_Info : Character_Info
{
    [SerializeField] protected Sprite npcDialogueSprite;
    [SerializeField] protected string[] dialogue;
    [SerializeField] protected Dialogue_Box theDialogueBox;

    // A dummy method to give the child-classes a method to override that can still be called from a NPC_Info-object.
    public virtual void Interact()
    {
        if (gameObject.GetComponent<NPC_Movement>() != false)
        {
            gameObject.GetComponent<NPC_Movement>().TurnToPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().GetFacing());
        }
        theDialogueBox.UpdateDialogue(this);
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
