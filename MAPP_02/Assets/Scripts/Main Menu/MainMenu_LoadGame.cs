using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_LoadGame : MonoBehaviour
{
    [SerializeField] AudioThingy audioThingy;

    private void Awake()
    {
        if (!new FileInfo(Application.dataPath + "/save.txt").Exists)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void LoadGame()
    {
        Game_Controller.LoadGame();
        StartCoroutine(audioThingy.FadeOut());
    }
}
