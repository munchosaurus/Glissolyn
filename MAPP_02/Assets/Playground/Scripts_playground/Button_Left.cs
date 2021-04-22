using UnityEngine;

public class Button_Left : MonoBehaviour
{
    public void LeftClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveLeft();
    }
}
