using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_LoadGame : MonoBehaviour
{
    [SerializeField] AudioThingy audioThingy;

    private void Awake()
    {
        if (!new FileInfo(Application.persistentDataPath + "/save.txt").Exists)
        {
            gameObject.GetComponent<Button>().interactable = false;
        } else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
    public void LoadGame()
    {
        Game_Controller.LoadGame();
        StartCoroutine(audioThingy.FadeOut());
    }
}
