using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Initializer : MonoBehaviour
{
    [SerializeField] private Dialogue_Box theDialogueBox;
    [SerializeField] private QuestLog theQuestLog;
    [SerializeField] private Player_Info thePlayerInfo;
    [SerializeField] private Menu theMenu;
    [SerializeField] private GameObject worldInterface;
    [SerializeField] private GameObject battleSystem;
    [SerializeField] private Character_Screen characterScreen;

    private int playerStartingLevel = 1;
    private int playerStartingHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        Game_Controller.SetDialogueBox(theDialogueBox);
        Game_Controller.SetQuestLog(theQuestLog);
        Game_Controller.SetPlayerInfo(thePlayerInfo);
        Game_Controller.SetMenu(theMenu);
        Game_Controller.SetWorldInterface(worldInterface);
        Game_Controller.SetBattleSystem(battleSystem);
        Game_Controller.SetCharacterScreen(characterScreen);
        Combat_Info.Initialize();
        thePlayerInfo.SetPlayerLevel(playerStartingLevel);
        thePlayerInfo.SetHealth(playerStartingHealth);
        thePlayerInfo.SetName(Game_Controller.GetPlayerName());
        characterScreen.Initialize();
    }
}
