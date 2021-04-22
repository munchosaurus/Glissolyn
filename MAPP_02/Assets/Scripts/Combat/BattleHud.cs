using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;

    [SerializeField] HPBar hpBar;

   /* public void SetData()
    {
        nameText.text = Combat_Info.GetEnemyInfo().GetName();
        levelText.text = Combat_Info.GetEnemyInfo().GetLevel();
    }
   */

    public void SetData(Character character)
    {
        nameText.text = character._base.getName();
        levelText.text = "Lvl " + character.level;
        hpBar.SetHP();
    }

}
