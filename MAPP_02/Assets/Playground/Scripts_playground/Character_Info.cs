using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Info : MonoBehaviour
{
    [SerializeField] protected new string name;
    [SerializeField] protected int health;
    [SerializeField] protected int strength;
    [SerializeField] protected int agility;
    [SerializeField] protected int intelligence;

    protected GameObject thePlayer;
    protected Dictionary<int, Ability> abilities = new Dictionary<int, Ability>();

    private void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

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

    public Dictionary<int, Ability> GetAbilities()
    {
        return abilities;
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

    public void AddAbility(Ability ability)
    {
        abilities.Add(ability.GetID(), ability);
    }

    public void RemoveAbility(int abilityID)
    {
        abilities.Remove(abilityID);
    }
}
