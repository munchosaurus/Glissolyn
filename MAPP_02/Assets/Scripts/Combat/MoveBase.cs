using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Character/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Type type;
    [SerializeField] StatType statType;
    [SerializeField] int power;

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public new Type GetType()
    {
        return type;
    }

    public int GetPower()
    {
        return power;
    }

    public StatType GetStatType()
    {
        return statType;
    }
}

public enum StatType
{
    STRENGTH,
    AGILITY,
    INTELLIGENCE
}
