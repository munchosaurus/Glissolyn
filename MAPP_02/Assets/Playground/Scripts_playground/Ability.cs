using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected int id;
    protected string name;
    protected Character_Info user;

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

    public virtual void Use(Character_Info user, Character_Info target)
    {
        
    }
}
