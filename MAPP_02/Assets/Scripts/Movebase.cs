using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Enemy/Create new move")]
public class MoveBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] EnemyType type;
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

    public EnemyType GetType()
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
