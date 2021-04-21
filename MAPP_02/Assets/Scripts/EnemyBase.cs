using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create new enemy")]
public class EnemyBase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite enemySprite;

    [SerializeField] EnemyType type;

    //Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMoves> learnableMoves;

    public string getName()
    {
        return name;
    }

    public string Description()
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

    public int GetSpAttack()
    {
        return spAttack;
    }

    public int GetSpDefense()
    {
        return spDefense;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public List<LearnableMoves> GetLearnableMoves()
    {
        return learnableMoves;
    }
}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase;
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


public enum EnemyType
{
    None,
    Undead,
    Monster,
    Beast,
    Humanoid,
    Magical
}


