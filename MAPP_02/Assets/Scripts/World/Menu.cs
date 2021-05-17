using UnityEngine;

public class Menu : MonoBehaviour
{

    public void LoadGameClick()
    {
        // TODO
    }

    public void SaveGameClick()
    {
        Game_Controller.GetDataBase().SaveGame();
    }

    public void SettingsClick()
    {
        // TODO
    }

    public void QuitClick()
    {
        Game_Controller.GoToMainMenu();
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Game_Controller.SetPause(gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }
}
