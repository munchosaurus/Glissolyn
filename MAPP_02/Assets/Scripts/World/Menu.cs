using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Settings settings;
    public void LoadGameClick()
    {
        Game_Controller.LoadGame();
        Game_Controller.GoToWorld();
    }

    public void SaveGameClick()
    {
        Game_Controller.GetDataBase().SaveGame();
    }

    public void SettingsClick()
    {
        settings.Toggle();
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
