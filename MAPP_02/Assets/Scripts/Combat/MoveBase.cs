using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Character/Create new move")]
public class MoveBase : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] CharacterType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int PP;

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public new CharacterType GetType()
    {
        return type;
    }

    public int GetPower()
    {
        return power;
    }

    public int GetAccuracy()
    {
        return accuracy;
    }

    public int GetPP()
    {
        return PP;
    }


}
