using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_LoadGame : MonoBehaviour
{
    [SerializeField] AudioThingy audioThingy;
    public void LoadGame()
    {
        Game_Controller.LoadGame();
        StartCoroutine(audioThingy.FadeOut());
    }
}
