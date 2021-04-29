using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public CharacterBase Base;
    public int Level;

    public int CurrentHP;
    public List<Move> Moves { get; set; }

    //TODO konstruktor tar emot level, före spelare samt fiende
    public Character(CharacterBase Base, int level)
    {
        this.Base = Base;
        Level = level;
        SetCurrentHP();
       
        Moves = new List<Move>();

        foreach (var move in Base.GetLearnableMoves())
        {
            if (move.GetLevel() <= Level)
            {
                Moves.Add(new Move(move.moveBase));
            }

            if (Moves.Count >= 4)
            {
                break;
            }
        }
    }

    public int MaxHP()
    {
        if (Base.GetTypes().Contains(CharacterType.Player))
        {
            return Base.GetMaxHP();
        }
        else
        {
            return (Base.GetMaxHP() * Level) / 5;
        }
    }

    public int GetCurrentHP()
    {
        return CurrentHP;
    }

    public void SetCurrentHP()
    {
        if (Base.GetTypes().Contains(CharacterType.Player))
        {
            CurrentHP = Game_Controller.GetPlayerInfo().GetHealth();
        }
        else
        {
            CurrentHP = MaxHP();
        }
    }

    public bool TakeDamage(Move move, Character attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        /*float a = (2 * character.Level + 10) / 250f;
        float d = a * move.Base.GetPower() * ((float)character.Attack() /Defense())+ 2;*/
        int damage = Mathf.FloorToInt(move.Base.GetPower() * modifiers);

        CurrentHP -= damage;
        if (Base.GetTypes().Contains(CharacterType.Player))
        {
            Game_Controller.GetPlayerInfo().ReduceHealth(damage);
        }

        if (GetCurrentHP() <= 0)
        {
            CurrentHP = 0;
            return true;
        }
        return false;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
