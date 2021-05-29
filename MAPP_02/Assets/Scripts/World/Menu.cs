using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] Button loadButton;

    public void LoadGameClick()
    {

        Game_Controller.LoadGame();
        Game_Controller.GoToWorld();

    }

    public void SaveGameClick()
    {
        Game_Controller.GetDataBase().SaveGame();
        loadButton.interactable = true;
    }

    public void SettingsClick()
    {
        settings.Toggle();
    }

    public void QuitClick()
    {
        PlayerPrefs.SetFloat("Volume", Game_Controller.GetPlayerInfo().gameObject.GetComponent<AudioSource>().volume);
        Game_Controller.GoToMainMenu();
    }

    public void Toggle()
    {
        if (!new FileInfo(Application.persistentDataPath + "/save.txt").Exists)
        {
            loadButton.interactable = false;
        }
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Game_Controller.SetPause(gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }
}
