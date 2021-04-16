using UnityEngine;

public abstract class Character_Info : MonoBehaviour
{
    protected new string name;
    protected int health;
    protected int strength;
    protected int agility;
    protected int intelligence;

    public string GetName()
    {
        return name;
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
        
    public void SetName(string name)
    {
        this.name = name;
    }

    public void ModifyStrength(int amount)
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
    }
}
