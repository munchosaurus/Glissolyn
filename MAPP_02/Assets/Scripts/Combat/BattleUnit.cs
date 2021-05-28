using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{  
    public Character Character { get; set; }
    [SerializeField] Animator playerMoveAnimator;

    public void Setup(CharacterBase _base, int level)
    {
        Character = new Character(_base, level);
        GetComponent<Image>().sprite = Character.Base.sprite;
    }

    public void PerformMove(string moveName)
    {
        playerMoveAnimator.SetTrigger(moveName);
    }
}
