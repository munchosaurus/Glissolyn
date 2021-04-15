using UnityEngine;

public class NPC_Info : Character_Info
{
    [SerializeField] protected Sprite npcDialogueSprite;
    [SerializeField] protected string[] Dialogue;

    // A dummy method to give the child-classes a method to override that can still be called from a NPC_Info-object.
    public virtual void Interact()
    {

    }
}
