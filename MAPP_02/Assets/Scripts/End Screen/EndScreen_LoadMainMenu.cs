using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen_LoadMainMenu : MonoBehaviour
{

    public void FinishGame()
    {
        Game_Controller.GoToMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
