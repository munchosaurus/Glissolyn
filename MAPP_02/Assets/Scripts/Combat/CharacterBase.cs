using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new player")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] new string name;
    [TextArea][SerializeField] string description;

    [SerializeField] public Sprite sprite;

    [SerializeField] CharacterType type;

    [SerializeField] int maxHP;
    [SerializeField] int strength;
    [SerializeField] int agility;
    [SerializeField] int intelligence;
    [SerializeField] int experienceBase;

    [SerializeField] List<LearnableMoves> learnableMoves;

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetMaxHP(int maxHP)
    {
        this.maxHP = maxHP;
    }

    public void ModifyMaxHP(int amount)
    {
        maxHP += amount;
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

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetMaxHP()
    {
        return maxHP;
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

    public int GetExperienceBase()
    {
        return experienceBase;
    }

    public new CharacterType GetType() => type;

    public List<LearnableMoves> GetLearnableMoves()
    {
        return learnableMoves;
    }
}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField] public MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase GetMove()
    {
        return moveBase;
    }

    public int GetLevel()
    {
        return level;
    }

}


public enum CharacterType
{
    None,
    Undead,
    Monster,
    Beast,
    Humanoid,
    Magical,
    Player
}


