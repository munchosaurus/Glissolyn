using System;
using UnityEngine;

public class NPC_Info : Character_Info
{
    [SerializeField] protected Sprite npcDialogueSprite;
    [TextArea] [SerializeField] protected string[] dialogue;
    [TextArea] [SerializeField] protected string[][] alternativeDialogue;

    protected int[] saveValues;
    [SerializeField] protected Vector3 spawnPos = new Vector3(0, 0, -50);

    private void Start()
    {
        if (spawnPos.z == -50)
        {
            spawnPos = gameObject.transform.position;
            if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcm))
            {
                npcm.SetSpawnPos(spawnPos);
            }
        }
    }

    public virtual void Init(int[] loadValues)
    {
        gameObject.SetActive(loadValues[0] == 1);
        transform.position = new Vector3(loadValues[1] + 0.5f, loadValues[2] + 0.5f, 0);
        spawnPos = new Vector3(loadValues[3] + 0.5f, loadValues[4] + 0.5f, 0);
        if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcm))
        {
            npcm.SetSpawnPos(spawnPos);
        }
    }

    public virtual int[] GetSaveValues()
    {
        saveValues = new int[5];
        saveValues[0] = gameObject.activeInHierarchy ? 1 : 0;
        saveValues[1] = Mathf.FloorToInt(transform.position.x);
        saveValues[2] = Mathf.FloorToInt(transform.position.y);
        saveValues[3] = Mathf.FloorToInt(spawnPos.x);
        saveValues[4] = Mathf.FloorToInt(spawnPos.y);

        return saveValues;
    }

    public virtual void Interact()
    {
        if (gameObject.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove))
        {
            npcmove.TurnToPlayer(Game_Controller.GetPlayerInfo().gameObject.GetComponent<Grid_movement>().GetFacing());
        }
        Game_Controller.GetDialogueBox().UpdateDialogue(this);

        if (gameObject.name.Contains("Old Man"))
        {
            Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1, gameObject.transform.position.z);
            Game_Controller.GetPlayerInfo().SetHealth(Game_Controller.GetPlayerInfo().GetMaxHealth());
            Game_Controller.GetPlayerInfo().SetRespawnPos(temp);
        }

        if (CompareTag("Quest")) {
            Game_Controller.GetQuestLog().UpdateQuestAfterInteraction(gameObject.name);
            
        }
    }

    public string[] GetDialogue()
    {
        return dialogue;
    }

    public Sprite GetDialogueSprite()
    {
        return npcDialogueSprite;
    }

    public void ChangeDialogue(int index) 
    {
        dialogue = alternativeDialogue[index];
    }
}
