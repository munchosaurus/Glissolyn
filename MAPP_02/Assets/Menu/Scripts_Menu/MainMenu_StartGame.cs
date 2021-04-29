using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
    
    
{
    [SerializeField] private GameObject introductionScreen;

    public void openIntroductionScreen()
    {
        introductionScreen.SetActive(true);
    }
}

