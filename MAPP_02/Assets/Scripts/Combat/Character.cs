using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public CharacterBase _base;
    public int level;

    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Character(CharacterBase _base, int level)
    {
        this._base = _base;
        this.level = level;
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
         


        int Attack()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 5);
        }
        int Defense()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 5);
        }
        int SpAttack()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 5);
        }
        int SpDefense()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 5);
        }
        int Speed()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 5);
        }
        int MaxHP()
        {
            return Mathf.FloorToInt((_base.GetAttack() * level / 100f) + 10);
        }
    
}
