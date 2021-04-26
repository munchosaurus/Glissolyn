using UnityEngine;

public class Button_Right : MonoBehaviour
{
    public void RightClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveRight();
    }
}