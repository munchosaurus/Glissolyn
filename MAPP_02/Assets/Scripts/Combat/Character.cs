using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public CharacterBase Base;
    public int Level;

    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Character(CharacterBase _base, int level)
    {
        Base = _base;
        Level = level;
        HP = MaxHP();

        Moves = new List<Move>();

             foreach(var move in _base.GetLearnableMoves())
             {
                 if(move.GetLevel() <= level)
                 {
                     Moves.Add(new Move(move.moveBase));
                 }

                 if(Moves.Count >= 4)
                 {
                     break;
                 }
             }
    }
         

        public int Attack()
        {
        //return Base.GetAttack();
        return Mathf.FloorToInt((Base.GetAttack() * Level) / 100f) + 5;
        }
        public int Defense()
        {
      //  return Base.GetDefense();
        return Mathf.FloorToInt((Base.GetDefense() * Level) / 100f) + 5;
    }

        public int MaxHP()
        {
       // return Base.GetMaxHP();
        return Mathf.FloorToInt((Base.GetMaxHP() * Level) / 100f) + 10;
    }

    public bool TakeDamage(Move move, Character character)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * character.Level + 10) / 250f;
        float d = a * move.Base.GetPower() * ((float)character.Attack() /Defense())+ 2;
        int damage = Mathf.FloorToInt(move.Base.GetPower() * modifiers);

        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            
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
