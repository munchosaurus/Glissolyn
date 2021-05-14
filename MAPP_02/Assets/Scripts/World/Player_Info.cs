using UnityEngine;

public class Player_Info : Character_Info
{
    [SerializeField] private Transform interactChecker;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private CharacterBase Base;
    [SerializeField] private Sprite playerSprite;
    [SerializeField]private GameObject spawnPosition;

    private int maxHealth;
    private int health;
    private int strength;
    private int agility;
    private int intelligence;

    private int playerLevel; 
    private int statPoints;
    private int experience;
    private int nextLevelExperience;

    private void SetNextLevelExperience()
    {
        nextLevelExperience = playerLevel * 10;
    }

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

    public int GetNextLevelExperience()
    {
        return nextLevelExperience;
    }

    public CharacterBase GetBase()
    {
        return Base;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetSpawnPosition(GameObject spawn)
    {
        print("oii");
        this.spawnPosition = spawn;
        
    }

    public void ModifyMaxHealthAdd(int amount)
    {
        maxHealth += amount;
    }

    public void ModifyMaxHealthMultiply(int amount)
    {
        maxHealth *= amount;
    }

    public int GetStrength()
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
    }

    public int GetStatPoints()
    {
        return statPoints;
    }

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
    }

    public void SetPlayerLevel(int level)
    {
        playerLevel = level;
        SetNextLevelExperience();
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            gameObject.transform.position = spawnPosition.transform.position;
        }
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
    
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetStrength(int strength)
    {
        this.strength = strength;
    }

    public void ModifyStrength(int amount)
    {
        strength += amount;
    }

    public void SetAgility(int agility)
    {
        this.agility = agility;
    }

    public void ModifyAgility(int amount)
    {
        agility += amount;
    }

    public void SetIntelligence(int intelligence)
    {
        this.intelligence = intelligence;
    }

    public void ModifyIntelligence(int amount)
    {
        intelligence += amount;
    }

    public void SetExperience(int amount)
    {
        experience = amount;
    }
    
    public void SetStatPoints(int amount)
    {
        statPoints = amount;
    }

    public void ModifyExperience(int amount)
    {
        experience += amount;
        if(experience >= nextLevelExperience)
        {
            playerLevel++;
            statPoints += 3;
            Game_Controller.GetDialogueBox().UpdateDialogue(new string[] { "You leveled up!", "You now have " + statPoints + " stat points!", "You are now level " + playerLevel});
            SetNextLevelExperience();
            if(experience >= nextLevelExperience)
            {
                ModifyExperience(0);
            }
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
        }
        else if(interactable!= null && !Game_Controller.IsGamePaused() && Game_Controller.IsCombatActive())
        {
            interactable.GetComponent<NPC_Info>().Interact();
            Game_Controller.RunTransition();
           
        }

        else
        {
            Game_Controller.GetDialogueBox().NextDialoguePart();
        }
    }
}
