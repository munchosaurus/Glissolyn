using UnityEngine;

public class Interface_Buttons : MonoBehaviour
{
    [SerializeField] private Transform objectChecker;
    [SerializeField] private LayerMask interactableLayer;

    public void UpClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveUp();
    }

    public void LeftClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveLeft();
    }

    public void RightClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveRight();
    }

    public void DownClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveDown();
    }

    public void QuestLogClick()
    {
        Game_Controller.GetQuestLog().Toggle();
    }

    public void MenuClick()
    {
        Game_Controller.GetMenu().Toggle();
    }
}
