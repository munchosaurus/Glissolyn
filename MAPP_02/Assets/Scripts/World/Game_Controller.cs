using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game_Controller
{
    private static readonly int MAIN_MENU_SCENE_ID = 0;

    private static bool isGamePaused;
    private static bool isCombatActive;
    private static bool isLoaded;
    private static Dialogue_Box theDialogueBox;
    private static QuestLog theQuestLog;
    private static Player_Info thePlayerInfo;
    private static Menu theMenu;
    private static Character_Screen characterScreen;
    private static GameObject worldInterface;
    private static GameObject battleSystem;
    private static DataBase dataBase;
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

    public static void SetDataBase(DataBase db)
    {
        dataBase = db;
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

    public static GameObject GetTransition()
    {
        return transition;
    }

    public static void RunTransition()
    {
        transition.GetComponentInChildren<Transition>().RunTransition();
    }

    public static Character_Screen GetCharacterScreen()
    {
        return characterScreen;
    }

    public static DataBase GetDataBase()
    {
        return dataBase;
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
    
    public static void ToggleWorldInterface(bool toggle)
    {
        worldInterface.SetActive(toggle);
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
        switch(qcs)
        {
            case QuestClearState.OPEN_ELDHAM_EAST_EXIT:
                dataBase.GetNpcByID(42).gameObject.SetActive(false);
                dataBase.GetNpcByID(43).gameObject.SetActive(false);
                break;
            case QuestClearState.ELDHAM_PURIFIED:
                dataBase.GetNpcByID(44).gameObject.SetActive(false);
                dataBase.GetNpcByID(45).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public static void LoadGame()
    {
        isLoaded = true;
    }

    public static bool IsLoaded()
    {
        return isLoaded;
    }
}
