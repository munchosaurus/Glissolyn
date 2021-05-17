using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_LoadGame : MonoBehaviour
{
    public void LoadGame()
    {
        Game_Controller.LoadGame();
        SceneManager.LoadScene(1);
    }
}
