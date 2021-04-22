using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{

    [SerializeField] CharacterBase _base;
    [SerializeField] int level;

    public Character character { get; set; }

    public void Setup()
    {
        character = new Character(_base, level);

        GetComponent<Image>().sprite = character._base.sprite;
        
    }
}
