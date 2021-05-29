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
    }

    override
    public int[] GetSaveValues()
    {
        saveValues = new int[5];
        saveValues[0] = gameObject.activeInHierarchy ? 1 : 0;
        saveValues[1] = (int)transform.position.x;
        saveValues[2] = (int)transform.position.y;
        saveValues[3] = dead ? 1 : 0;
        saveValues[4] = (int) timer;

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
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if(gameObject.TryGetComponent<Enemy_Find_player>(out Enemy_Find_player efp))
        {
            efp.enabled = true;
            efp.StartTimer(3);
        }
    }
}
