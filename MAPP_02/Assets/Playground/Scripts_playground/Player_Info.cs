using UnityEngine;

public class Player_Info : Character_Info
{
    [SerializeField] private Transform interactChecker;
    [SerializeField] private LayerMask interactableLayer;

    private int playerLevel; 
    private int statPoints;
    private int experience;

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public int GetExperience()
    {
        return experience;
    }

    public void ModifyExperience(int amount)
    {
        experience += amount;
    }

    public bool SpendStatPoint()
    {
        if(statPoints > 0)
        {
            statPoints--;
            return true;
        }

        return false;
    }

    public void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactChecker.position, 0.3f, interactableLayer);
        if (interactable != null && !Game_Controller.IsGamePaused())
        {
            interactable.GetComponent<NPC_Info>().Interact();
            if (interactable.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove))
            {
                npcmove.TurnToPlayer(transform.position);
            }
        }
        else
        {
            Game_Controller.GetDialogueBox().NextDialoguePart();
        }
    }
}
