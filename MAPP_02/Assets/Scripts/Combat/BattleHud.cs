using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Character _character;

   /* public void SetData()
    {
        nameText.text = Combat_Info.GetEnemyInfo().GetName();
        levelText.text = Combat_Info.GetEnemyInfo().GetLevel();
    }
   */

    public void SetData(Character character)
    {
        _character = character;
        nameText.text = character.Base.getName();
        levelText.text = "Lvl " + character.level;
        hpBar.SetHP((float)character.HP / character.MaxHP());
    }

    public void UpdateHP()
    {
        hpBar.SetHP((float)_character.HP / _character.MaxHP());
    }
}
