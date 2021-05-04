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
    [SerializeField] private List<NPC_Info> NPCs;

    private int playerStartingLevel = 1;
    private int playerStartingHealth = 100;
    private int playerStartingStrength = 1;
    private int playerStartingAgility = 1;
    private int playerStartingIntelligence = 10;
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
        Combat_Info.Initialize();
        InitializePlayer();
        characterScreen.Initialize();
        foreach(NPC_Info npc in NPCs)
        {
            npc.SetupDialogue();
        }
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
    }
}
