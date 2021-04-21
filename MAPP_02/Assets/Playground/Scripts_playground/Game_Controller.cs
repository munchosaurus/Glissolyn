using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game_Controller
{
    private static readonly int COMBAT_SCENE_ID = 2;
    private static readonly int WORLD_SCENE_ID = 1;

    private static bool isGamePaused;

    public static void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public static bool IsGamePaused()
    {
        return isGamePaused;
    }

    public static void StartCombat()
    {
        SceneManager.LoadScene(COMBAT_SCENE_ID);
    }

    public static void EndCombat()
    {
        SceneManager.LoadScene(WORLD_SCENE_ID);
    }
}
