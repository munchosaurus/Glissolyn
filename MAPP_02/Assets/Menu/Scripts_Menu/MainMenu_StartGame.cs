using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
    
    
{
    [SerializeField] private GameObject introductionScreen;
    [SerializeField] private GameObject mainMenuPanel;
    public void openIntroductionScreen()
    {
        mainMenuPanel.SetActive(false);
        introductionScreen.SetActive(true);
    }
}

