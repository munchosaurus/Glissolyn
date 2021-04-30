using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_SelectName : MonoBehaviour
{
    [SerializeField] private GameObject nameSelection;
    [SerializeField] private GameObject introductionScreen;


    public void SelectName()
    {
        nameSelection.SetActive(true);
        introductionScreen.SetActive(false);
    }

}
