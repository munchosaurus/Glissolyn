using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new player")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] new string name;
    [TextArea][SerializeField] string description;

    [SerializeField] public Sprite sprite;

    [SerializeField] List<Type> types;

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

    public List<Type> GetTypes() => types;

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


public enum Type
{
    None,
    Undead,
    Monster,
    Beast,
    Humanoid,
    Magical,
    Player
}


