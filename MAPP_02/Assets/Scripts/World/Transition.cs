using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;

    public void RunTransition()
    {
        transition.SetTrigger("Start");
    }

    public void ToggleBattleSystem()
    {
        Game_Controller.ToggleCombatState(!Game_Controller.IsCombatActive());

        if (Game_Controller.GetBattleSystem().gameObject.activeInHierarchy)
        {
            Game_Controller.GetBattleSystem().StartCombat();
        }
    }
}
