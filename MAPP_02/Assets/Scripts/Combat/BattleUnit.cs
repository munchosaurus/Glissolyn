using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{

    [SerializeField] CharacterBase _base;
    [SerializeField] int level;

    public Character Character { get; set; }

    public void Setup()
    {
        Character = new Character(_base, level);

        GetComponent<Image>().sprite = Character.Base.sprite;
        
    }
}
