using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Initializer : MonoBehaviour
{
    [SerializeField] private Dialogue_Box theDialogueBox;
    [SerializeField] private QuestLog theQuestLog;
    [SerializeField] private Player_Info thePlayerInfo;
    [SerializeField] private Menu theMenu;
    [SerializeField] private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        Combat_Info.Initialize();
        Game_Controller.SetDialogueBox(theDialogueBox);
        Game_Controller.SetQuestLog(theQuestLog);
        Game_Controller.SetPlayerInfo(thePlayerInfo);
        Game_Controller.SetMenu(theMenu);
    }
}
