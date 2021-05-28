using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Initializer : MonoBehaviour
{
    [SerializeField] private DataBase dataBase;
    [SerializeField] private Dialogue_Box theDialogueBox;
    [SerializeField] private QuestLog theQuestLog;
    [SerializeField] private Player_Info thePlayerInfo;
    [SerializeField] private Menu theMenu;
    [SerializeField] private GameObject worldInterface;
    [SerializeField] private GameObject battleSystem;
    [SerializeField] private Character_Screen characterScreen;
    [SerializeField] private GameObject transition;

    private int playerStartingLevel = 1;
    private int playerStartingHealth = 100;
    private int playerStartingStrength = 3;
    private int playerStartingAgility = 3;
    private int playerStartingIntelligence = 3;
    private int playerStartingExperience = 0;
    private int playerStartingStatPoints = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Game_Controller.SetDialogueBox(theDialogueBox);
        Game_Controller.SetQuestLog(theQuestLog);
        Game_Controller.SetPlayerInfo(thePlayerInfo);
        Game_Controller.SetMenu(theMenu);
        Game_Controller.SetWorldInterface(worldInterface);
        Game_Controller.SetBattleSystem(battleSystem);
        Game_Controller.SetCharacterScreen(characterScreen);
        Game_Controller.SetDataBase(dataBase);
        Game_Controller.SetTransition(transition);

        if (Game_Controller.IsLoaded())
        {
            dataBase.LoadGame();
            Game_Controller.SetPause(false);
        }
        else
        {
            dataBase.ResetQuests();
            InitializePlayer();
            Game_Controller.GetDataBase().SetCurrentAudioID(4);
        }
        Combat_Info.Initialize();
    }

    private void InitializePlayer()
    {
        thePlayerInfo.SetPlayerLevel(playerStartingLevel);
        thePlayerInfo.SetHealth(playerStartingHealth);
        thePlayerInfo.SetMaxHealth(playerStartingHealth);
        thePlayerInfo.SetStrength(playerStartingStrength);
        thePlayerInfo.SetAgility(playerStartingAgility);
        thePlayerInfo.SetIntelligence(playerStartingIntelligence);
        thePlayerInfo.SetExperience(playerStartingExperience);
        thePlayerInfo.SetStatPoints(playerStartingStatPoints);
        thePlayerInfo.SetName(Game_Controller.GetPlayerName());
        characterScreen.Initialize();
    }
}
