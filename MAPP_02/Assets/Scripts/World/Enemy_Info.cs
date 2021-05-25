using UnityEngine;

public class Enemy_Info : NPC_Info
{
    [SerializeField] CharacterBase Base;
    [SerializeField] int level;

    private float timer;
    private bool dead;

    void LateUpdate()
    {
        if (dead && !Game_Controller.IsGamePaused())
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Respawn();
            }
        }
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
        dead = true;
        timer = 30;
        transform.position = new Vector3(transform.position.x, transform.position.y, -20);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    public void Respawn()
    {
        dead = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if(gameObject.TryGetComponent<Enemy_Find_player>(out Enemy_Find_player efp))
        {
            efp.StartTimer(3);
        }
    }
}
