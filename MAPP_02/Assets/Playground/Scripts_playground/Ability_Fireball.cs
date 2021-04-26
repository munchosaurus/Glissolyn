using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Fireball : Ability
{
    private int DAMAGE = 2;

    public Ability_Fireball(string name, int id) : base(name, id)
    {
    }

    override
    public void Use(Character_Info user, Character_Info target)
    {
        target.ReduceHealth(user.GetIntelligence() * DAMAGE);
    }
}
