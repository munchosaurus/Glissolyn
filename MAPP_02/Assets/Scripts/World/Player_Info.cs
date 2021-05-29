using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Player_Info : Character_Info
{
    [SerializeField] private Transform interactChecker;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private CharacterBase Base;
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Transform startPos;

    [SerializeField] private bool enterGodMode;
    [SerializeField] private bool enterWeakassMode;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Image overlay;

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
        audioMixer.SetFloat("volume", -80);

        if (PlayerPrefs.HasKey("Volume"))
        {
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        } else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.5f;
        }

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
                SetName("Fragile Dude");
                Game_Controller.GetCharacterScreen().Initialize();
            }
            else
            {
                respawnPos = startPos.position;
                transform.position = respawnPos;
            }
            StartCoroutine(FadeInScene());
        }

        
    }

    private void SetNextLevelExperience()
    {
        nextLevelExperience = playerLevel * 10;
    }

    private void LevelUp()
    {
        experience -= nextLevelExperience;
        GiveStatPoints(3);
        SetPlayerLevel(playerLevel + 1);
        health = maxHealth;

        if (experience >= nextLevelExperience)
        {
            if (playerLevel < 100)
            {
                LevelUp();
            }
        }
        else
        {
            Game_Controller.GetDialogueBox().UpdateDialogue(new string[] { "You leveled up!", "You now have " + statPoints + " stat points!", "You are now level " + playerLevel + "!"});
        }
    }

    private IEnumerator ModifyExperienceCoroutineHack(int amount)
    {
        yield return new WaitForFixedUpdate();
        while (Game_Controller.GetDialogueBox().gameObject.activeInHierarchy)
        {
            yield return null;
        }

        if (playerLevel < 100)
        {
            Game_Controller.GetDialogueBox().UpdateDialogue(new string[] { "You gained " + amount + " experience!" });

            yield return new WaitForFixedUpdate();

            while (Game_Controller.GetDialogueBox().gameObject.activeInHierarchy)
            {
                yield return null;
            }

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


    public void Init(string name, int[] loadValues)
    {
        SetName(name);
        transform.position = new Vector3(loadValues[0] + 0.5f, loadValues[1] + 0.5f, 0);
        strength = loadValues[2];
        agility = loadValues[3];
        intelligence = loadValues[4];
        SetPlayerLevel(loadValues[5]);
        GiveStatPoints(loadValues[6]);
        experience = loadValues[7];
        maxHealth = loadValues[8];
        SetHealth(loadValues[9]);
        respawnPos = new Vector3(loadValues[10] + 0.5f, loadValues[11] + 0.5f, 0);
        Game_Controller.GetCharacterScreen().Initialize();
    }

    public int[] GetSaveValues()
    {
        saveValues = new int[12];
        saveValues[0] = (int)transform.position.x;
        saveValues[1] = (int)transform.position.y;
        saveValues[2] = strength;
        saveValues[3] = agility;
        saveValues[4] = intelligence;
        saveValues[5] = playerLevel;
        saveValues[6] = statPoints;
        saveValues[7] = experience;
        saveValues[8] = maxHealth;
        saveValues[9] = health;
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
        if (amount != 0)
        {
            StartCoroutine(ModifyExperienceCoroutineHack(amount));
        }
    }

    public void GiveStatPoints(int amount)
    {
        statPoints += amount;
        if(amount > 0)
        {
            Game_Controller.GetCharacterScreen().ShowNewStatPointIcon();
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

    public void Respawn()
    {
        transform.position = respawnPos;
        health = maxHealth;
    }
    
    public void SetRespawnPos(Vector3 newPos)
    {
        respawnPos = newPos;
    }

    public void ChangeMusic(int id)
    {
        StartCoroutine(FadeOutMusic(id));
    }

    private IEnumerator FadeOutMusic(int id)
    {
        float currentTime = 0;
        float duration = 0.3f;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(0, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            yield return null;
        }
        gameObject.GetComponent<AudioSource>().Stop();
        StartCoroutine(FadeInMusic(id));
    }

    private IEnumerator FadeOutScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        
        float currentTime = 0;
        float duration = 0.3f;

        Color targetColor;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(0, 0.0001f, 1);

        while (Game_Controller.GetDialogueBox().gameObject.activeInHierarchy)
        {
            yield return null;
        }
        overlay.gameObject.SetActive(true);
        while (currentTime < duration)
        {
            
            print(Time.timeScale);
            targetColor = overlay.color;
            targetColor.a = Mathf.Lerp(0, 1, currentTime / duration);
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            overlay.color = targetColor;
            yield return null;
        }
        gameObject.GetComponent<AudioSource>().Stop();
        Game_Controller.GoToEndScreen();
    }

    private IEnumerator FadeInMusic(int id)
    {
        gameObject.GetComponent<AudioSource>().clip = Game_Controller.GetDataBase().GetMUsicByID(id);
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = true;

        float currentTime = 0;
        float duration = 3;
        float targetVol = 0.3f;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVol, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            yield return null;
        }
        
    }

    private IEnumerator FadeInScene()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = true;

        float currentTime = 0;
        float duration = 3;
        float targetVol = 0.3f;

        Color targetColor;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVol, 0.0001f, 1);

        while (currentTime < duration)
        {
            targetColor = overlay.color;
            targetColor.a = Mathf.Lerp(1, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            overlay.color = targetColor;
            yield return null;
        }
        overlay.gameObject.SetActive(false);
    }

    public void FinishGame()
    {
        StartCoroutine(FadeOutScene());
    }
}
