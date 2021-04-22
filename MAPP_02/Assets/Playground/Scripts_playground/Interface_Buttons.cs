using UnityEngine;

public class Interface_Buttons : MonoBehaviour
{
    private Grid_movement playerMovementScript;

    private void Start()
    {
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>();
    }

    public void UpClick()
    {

        playerMovementScript.MoveUp();

    }

    public void LeftClick()
    {

        playerMovementScript.MoveLeft();
    }

    public void RightClick()
    {

        playerMovementScript.MoveRight();
    }

    public void DownClick()
    {

        playerMovementScript.MoveDown();
    }

    public void MoveRelease()
    {
        playerMovementScript.StopMoving();
    }


    public void QuestLogClick()
    {
        if (!Game_Controller.IsGamePaused() || Game_Controller.GetQuestLog().IsOpen())
        {
            Game_Controller.GetQuestLog().Toggle();
        }
    }

    public void MenuClick()
    {
        if (!Game_Controller.IsGamePaused() || Game_Controller.GetMenu().IsOpen())
        {
            Game_Controller.GetMenu().Toggle();
        }
    }

    public void InteractClick()
    {
        if (!Game_Controller.IsGamePaused())
        {
            Game_Controller.GetPlayerInfo().Interact();
        }
        else
        {
            Game_Controller.GetDialogueBox().NextDialoguePart();
        }
    }
}
