using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected int id;
    protected new string name;

    public Ability(string name, int id)
    {
        this.id = id;
        this.name = name;
    }

    public int GetID()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public virtual void Use(GameObject target)
    {

    }
}
