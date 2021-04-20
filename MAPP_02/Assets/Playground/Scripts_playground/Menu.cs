using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int mainMenuSceneIndex = 0;

    public void LoadGame()
    {
        // TODO
    }

    public void SaveGame()
    {
        // TODO
    }

    public void Settings()
    {
        // TODO
    }

    public void Quit()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
