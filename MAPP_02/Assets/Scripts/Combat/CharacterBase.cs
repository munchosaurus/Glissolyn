using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new player")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] public Sprite sprite;

    [SerializeField] CharacterType type;


    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;


    [SerializeField] List<LearnableMoves> learnableMoves;

    public string getName()
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

    public int GetAttack()
    {
        return attack;
    }

    public int GetDefense()
    {
        return defense;
    }


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
    Magical
}


