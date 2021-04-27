using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
    

{
    [SerializeField] private GameObject nameSelection;

    public void StartGame()
    {
        nameSelection.SetActive(true);
    }

}

