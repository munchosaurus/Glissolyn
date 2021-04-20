using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected static int ABILITY_ID_COUNTER = 0; // Static variable, its shared between all Ability-objects to keep track of how many abilities have been assigned.
    protected int id;
    protected new string name;

    public Ability(string name)
    {
        this.id = ABILITY_ID_COUNTER;
        this.name = name;
        ABILITY_ID_COUNTER++; // Increase ABILITY_ID_COUNTER by 1 to make sure the next ability that is created has an ID that is 1 higher than this quest.
    }

    public int GetID()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public void Use(GameObject target)
    {

    }
}
