using UnityEngine;

public class Enemy_Info : NPC_Info
{
    [SerializeField] CharacterBase Base;
    [SerializeField] int level;
    [SerializeField] bool isBoss;

    private float timer;
    private bool dead;

    void LateUpdate()
    {
        if (dead && !Game_Controller.IsGamePaused())
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
                Respawn();
            }
        }
    }

    override
    public void Init(int[] loadValues)
    {
        gameObject.SetActive(loadValues[0] == 1);
        transform.position = new Vector3(loadValues[1] + 0.5f, loadValues[2] + 0.5f, 0);
        dead = loadValues[3] == 1;
        timer = loadValues[4];
        spawnPos = new Vector3(loadValues[5] + 0.5f, loadValues[6] + 0.5f, 0);
        if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcm))
        {
            npcm.SetSpawnPos(spawnPos);
        }
        if (dead)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -20);
        }
    }

    override
    public int[] GetSaveValues()
    {
        saveValues = new int[7];
        saveValues[0] = gameObject.activeInHierarchy ? 1 : 0;
        saveValues[1] = Mathf.FloorToInt(transform.position.x);
        saveValues[2] = Mathf.FloorToInt(transform.position.y);
        saveValues[3] = dead ? 1 : 0;
        saveValues[4] = Mathf.FloorToInt(timer);
        saveValues[5] = Mathf.FloorToInt(spawnPos.x);
        saveValues[6] = Mathf.FloorToInt(spawnPos.y);

        return saveValues;
    }

    override
    public void Interact()
    {
        base.Interact();
    }

    public CharacterBase GetBase()
    {
        return Base;
    }

    public int GetLevel()
    {
        return level;
    }

    public void Die()
    {
        if (isBoss)
        {
            gameObject.SetActive(false);
        }
        dead = true;
        timer = 30;
        transform.position = new Vector3(transform.position.x, transform.position.y, -20);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if(gameObject.TryGetComponent<Enemy_Find_player>(out Enemy_Find_player efp))
        {
            efp.enabled = false;
        }
    }
    
    public void Respawn()
    {
        dead = false;
        transform.position = spawnPos;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if(gameObject.TryGetComponent<Enemy_Find_player>(out Enemy_Find_player efp))
        {
            efp.enabled = true;
            efp.StartTimer(3);
        }
    }

    public bool GetIsBoss()
    {
        return isBoss;
    }
}
