using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] Player_Info PlayerUnit;
    [SerializeField] BattleHud playerHud;

    void Start()
    {
        SetupBattle();
        
    }

    public void SetupBattle()
    {
 //       PlayerUnit.Setup();
  //      playerHud.SetData(PlayerUnit);
    }

}
