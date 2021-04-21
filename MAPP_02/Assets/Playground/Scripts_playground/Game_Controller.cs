using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game_Controller
{
    private static readonly int COMBAT_SCENE_ID = 2;
    private static readonly int WORLD_SCENE_ID = 1;

    private static bool isGamePaused;
    private static Dialogue_Box theDialogueBox;
    private static QuestLog theQuestLog;
    private static Player_Info thePlayerInfo;

    public static void SetDialogueBox(Dialogue_Box db)
    {
        theDialogueBox = db;
    }

    public static void SetQuestLog(QuestLog ql)
    {
        theQuestLog = ql;
    }

    public static void SetPlayerInfo(Player_Info pi)
    {
        thePlayerInfo = pi;
    }

    public static QuestLog GetQuestLog()
    {
        return theQuestLog;
    }

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
