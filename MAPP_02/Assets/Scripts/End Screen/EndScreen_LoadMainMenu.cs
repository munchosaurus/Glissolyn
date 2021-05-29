using UnityEngine;


public class EndScreen_LoadMainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public void FinishGame()
    {
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        Game_Controller.GoToMainMenu();
    }

    public void QuitGame()
    {
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        Application.Quit();
    }
}
