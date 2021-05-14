using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game_Controller
{
    private static readonly int MAIN_MENU_SCENE_ID = 0;
    //private static readonly int WORLD_SCENE_ID = 1;
    //private static readonly int COMBAT_SCENE_ID = 2;

    private static bool isGamePaused;
    private static bool isCombatActive;
    private static Dialogue_Box theDialogueBox;
    private static QuestLog theQuestLog;
    private static Player_Info thePlayerInfo;
    private static Menu theMenu;
    private static Character_Screen characterScreen;
    private static GameObject worldInterface;
    private static GameObject battleSystem;
    private static GameObject transition;

    private static string playerName;

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

    public static void SetMenu(Menu menu)
    {
        theMenu = menu;
    }

    public static void SetWorldInterface(GameObject wi)
    {
        worldInterface = wi;
    }

    public static void SetBattleSystem(GameObject bs)
    {
        battleSystem = bs;
    }

    public static void SetTransition(GameObject t)
    {
        transition = t;
    }

    public static void SetCharacterScreen(Character_Screen cs)
    {
        characterScreen = cs;
    }

    public static QuestLog GetQuestLog()
    {
        return theQuestLog;
    }

    public static Dialogue_Box GetDialogueBox()
    {
        return theDialogueBox;
    }

    public static Player_Info GetPlayerInfo()
    {
        return thePlayerInfo;
    }

    public static Menu GetMenu()
    {
        return theMenu;
    }

    public static void RunTransition()
    {
        transition.GetComponent<Transition>().RunTransition();
    }

    public static Character_Screen GetCharacterScreen()
    {
        return characterScreen;
    }

    public static void SetPause(bool toggle)
    {
        if (toggle)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isGamePaused = toggle;
    }

    public static bool IsGamePaused()
    {
        return isGamePaused;
    }

    public static void ToggleCombatState(bool toggle)
    {
        worldInterface.SetActive(!toggle);
        battleSystem.SetActive(toggle);
        

        isCombatActive = toggle;

        
    }

    public static bool IsCombatActive()
    {
        return isCombatActive;
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_ID);
    }

    public static string GetPlayerName()
    {
        return playerName;
    }

    public static void SetPlayerName(string pn)
    {
        playerName = pn;
    }

    public static BattleSystem GetBattleSystem()
    {
        return battleSystem.GetComponent<BattleSystem>();
    }

    public static void UpdateWorldToQuestClearState(QuestClearState qcs)
    {
        //TODO If-satser för om qcs == <ett QuestClearState> och vad som ska hända i så fall.
    }
}
