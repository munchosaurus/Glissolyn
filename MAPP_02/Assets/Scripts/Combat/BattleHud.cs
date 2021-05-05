using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Character character;

   /* public void SetData()
    {
        nameText.text = Combat_Info.GetEnemyInfo().GetName();
        levelText.text = Combat_Info.GetEnemyInfo().GetLevel();
    }
   */

    public void SetData(Character character)
    {
        this.character = character;
        nameText.text = character.Base.GetName();
        levelText.text = "Lvl: " + character.Level;
        hpBar.SetHP((float)character.GetCurrentHP() / character.GetMaxHP());
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SmoothHPChange((float) character.GetCurrentHP() / character.GetMaxHP());
    }
}
