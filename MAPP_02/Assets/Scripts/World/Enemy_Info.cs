using UnityEngine;

public class Enemy_Info : NPC_Info
{
    [SerializeField] CharacterBase Base;
    [SerializeField] int level;
    

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
}
