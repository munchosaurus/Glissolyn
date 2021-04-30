using UnityEngine;

public class Player_Info : Character_Info
{
    [SerializeField] private Transform interactChecker;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private CharacterBase Base;

    private int health;
    /*private int strength;
    private int agility;
    private int intelligence;*/

    private int playerLevel; 
    private int statPoints;
    private int experience;

    public void SetName(string name)
    {
        this.name = name;
        Base.SetName(name);
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public int GetExperience()
    {
        return experience;
    }

    public CharacterBase GetBase()
    {
        return Base;
    }

    public int GetHealth()
    {
        return health;
    }

    /*public int GetStrength()
    {
        return strength;
    }

    public int GetAgility()
    {
        return agility;
    }

    public int GetIntelligence()
    {
        return intelligence;
    }*/

    public int GetStatPoints()
    {
        return statPoints;
    }

    public void SetPlayerLevel(int level)
    {
        playerLevel = level;
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    /*public void ModifyStrength(int amount)
    {
        strength += amount;
    }

    public void ModifyAgility(int amount)
    {
        agility += amount;
    }

    public void ModifyIntelligence(int amount)
    {
        intelligence += amount;
    }*/

    public void ModifyExperience(int amount)
    {
        experience += amount;
        if(experience >= playerLevel * 10)
        {
            print("Player level increased");
            playerLevel++;
            statPoints += 3;
        }
    }

    public void SpendStatPoint()
    {
        statPoints--;
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
