using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadGameClick()
    {
        // TODO
    }

    public void SaveGameClick()
    {
        // TODO
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
    }
}
