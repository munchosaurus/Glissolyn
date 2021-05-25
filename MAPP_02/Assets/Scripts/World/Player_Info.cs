using Unity.Mathematics;
using UnityEngine;

public class Player_Info : Character_Info
{
    [SerializeField] private Transform interactChecker;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private CharacterBase Base;
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private GameObject startPos;

    [SerializeField] private bool enterGodMode;
    [SerializeField] private bool enterWeakassMode;

    private int maxHealth;
    private int health;
    private int strength;
    private int agility;
    private int intelligence;

    private int playerLevel; 
    private int statPoints;
    private int experience;
    private int nextLevelExperience;

    private Vector3 respawnPos;
    private int[] saveValues;

    private void Start()
    {
        if (!Game_Controller.IsLoaded())
        {
            if (enterGodMode)
            {
                strength = 100;
                agility = 100;
                intelligence = 100;
                SetPlayerLevel(100);
                SetHealth(maxHealth);
                ModifyExperience(0);
                SetName("Chuck Norris");
                Game_Controller.GetCharacterScreen().Initialize();
            }else if (enterWeakassMode)
            {
                strength = 1;
                agility = 1;
                intelligence = 1;
                SetPlayerLevel(1);
                SetHealth(5);
                ModifyExperience(0);
                SetName("Chuck Norris");
                Game_Controller.GetCharacterScreen().Initialize();
            }
            else
            {
                transform.position = respawnPos;
            }
        }
    }

    private void SetNextLevelExperience()
    {
        nextLevelExperience = playerLevel * 10;
    }

    private void LevelUp()
    {
        experience -= nextLevelExperience;
        playerLevel++;
        statPoints += 3;

        SetNextLevelExperience();
        if (experience >= nextLevelExperience)
        {
            ModifyExperience(0);
        }
        else
        {
            Game_Controller.GetDialogueBox().UpdateDialogue(new string[] { "You leveled up!", "You now have " + statPoints + " stat points!", "You are now level " + playerLevel });
        }
    }

    public void Init(string name, int[] loadValues)
    {
        SetName(name);
        transform.position = new Vector3(loadValues[0] + 0.5f, loadValues[1] + 0.5f, 0);
        maxHealth = loadValues[2];
        SetHealth(loadValues[3]);
        strength = loadValues[4];
        agility = loadValues[5];
        intelligence = loadValues[6];
        SetPlayerLevel(loadValues[7]);
        ModifyExperience(0);
        statPoints = loadValues[8];
        experience = loadValues[9];
        respawnPos = new Vector3(loadValues[10] + 0.5f, loadValues[11] + 0.5f, 0);
        Game_Controller.GetCharacterScreen().Initialize();
    }

    public int[] GetSaveValues()
    {
        saveValues = new int[12];
        saveValues[0] = (int)transform.position.x;
        saveValues[1] = (int)transform.position.y;
        saveValues[2] = maxHealth;
        saveValues[3] = health;
        saveValues[4] = strength;
        saveValues[5] = agility;
        saveValues[6] = intelligence;
        saveValues[7] = playerLevel;
        saveValues[8] = statPoints;
        saveValues[9] = experience;
        saveValues[10] = (int)respawnPos.x;
        saveValues[11] = (int)respawnPos.y;

        return saveValues;
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
        SetMaxHealth(70 + (30 * playerLevel));
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
        if(this.health > maxHealth)
        {
            this.health = maxHealth;
        }
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
        if (playerLevel < 100)
        {
            experience += amount;
            if (experience >= nextLevelExperience)
            {
                LevelUp();
            }
        }
        else
        {
            experience = nextLevelExperience - 1;
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
        else
        {
            Game_Controller.GetDialogueBox().NextDialoguePart();
        }
    }

    public Vector3 GetRespawnPos()
    {
        
        if (respawnPos.Equals(new Vector3(0,0,0)))
        {
            return startPos.transform.position;
        } else
        {
            return respawnPos;
        }
    }
    
    public void SetRespawnPos(Vector3 newPos)
    {
        respawnPos = newPos;
    }
}
