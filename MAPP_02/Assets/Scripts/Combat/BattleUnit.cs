using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{  
    public Character Character { get; set; }

    public void Setup(CharacterBase _base, int level)
    {
        Character = new Character(_base, level);
        GetComponent<Image>().sprite = Character.Base.sprite;
    }
}
