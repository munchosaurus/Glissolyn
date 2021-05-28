using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private int strength;
    private int agility;
    private int intelligence;

    public CharacterBase Base;
    public int Level;
    public List<Type> weaknesses = new List<Type>();
    public List<Type> strengths = new List<Type>();

    public int CurrentHP;
    public int maxHP;
    public List<Move> Moves { get; set; }

    public Character(CharacterBase Base, int level)
    {
        this.Base = Base;
        Level = level;
        SetStats();
        SetMaxHP();
        SetCurrentHP();
        foreach(Type type in Base.GetTypes())
        {
            GenerateCounters(type);
        }
        
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

    private void SetStats()
    {
        if (!Base.GetTypes().Contains(Type.Player))
        {
            strength = Base.GetStrength() * Level;
            agility = Base.GetAgility() * Level;
            intelligence = Base.GetIntelligence() * Level;
        }
        else
        {
            strength = Game_Controller.GetPlayerInfo().GetStrength();
            agility = Game_Controller.GetPlayerInfo().GetAgility();
            intelligence = Game_Controller.GetPlayerInfo().GetIntelligence();
        }
    }

    private void GenerateCounters(Type type)
    {
        
        switch (type)
        {
            case (Type.Humanoid):
                weaknesses.Add(Type.Undead);
                strengths.Add(Type.Monster);
                break;
            case (Type.Beast):
                weaknesses.Add(Type.Monster);
                strengths.Add(Type.Magical);
                break;
            case (Type.Magical):
                weaknesses.Add(Type.Beast);
                strengths.Add(Type.Undead);
                break;
            case (Type.Monster):
                weaknesses.Add(Type.Humanoid);
                strengths.Add(Type.Beast);
                break;
            case (Type.Undead):
                weaknesses.Add(Type.Magical);
                strengths.Add(Type.Humanoid);
                break;
            default:
                break;
        }
    }

    private int GetStat(StatType statType)
    {
        return statType switch
        {
            StatType.STRENGTH => strength,
            StatType.AGILITY => agility,
            StatType.INTELLIGENCE => intelligence,
            _ => throw new System.NotImplementedException()
        };
    }

    public void SetMaxHP()
    {
        if (Base.GetTypes().Contains(Type.Player))
        {
            maxHP = Game_Controller.GetPlayerInfo().GetMaxHealth();
        }
        else
        {
            maxHP = Mathf.FloorToInt(Base.GetMaxHP() + Base.GetMaxHP() * ((float)Level / 3));
        }
    }
    public int GetMaxHP()
    {
        return maxHP;
    }

    public int GetCurrentHP()
    {
        return CurrentHP;
    }

    public void SetCurrentHP()
    {
        if (Base.GetTypes().Contains(Type.Player))
        {
            CurrentHP = Game_Controller.GetPlayerInfo().GetHealth();
        }
        else
        {
            CurrentHP = GetMaxHP();
        }
    }

    public int TakeDamage(Move move, Character attacker)
    {
        float RNGModifier = Random.Range(0.85f, 1f);
        float typeModifier = 1;
        typeModifier += weaknesses.Contains(move.Base.GetType()) ? 0.5f : 0;
        typeModifier -= strengths.Contains(move.Base.GetType()) ? 0.5f : 0;

        int damage = Mathf.FloorToInt((move.Base.GetPower() * attacker.GetStat(move.Base.GetStatType())) * RNGModifier * typeModifier); // Move power * The characer stat for the move * a random number between 0.85 and 1 * 0.5, 1 or 1.5 depending on Type weakness/strength
        
        CurrentHP -= damage;
        if (Base.GetTypes().Contains(Type.Player))
        {
            Game_Controller.GetPlayerInfo().ReduceHealth(damage);
        }

        if (GetCurrentHP() <= 0)
        {
            CurrentHP = 0;
        }
        return damage;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
