using UnityEngine;

public class Button_Down : MonoBehaviour
{
    public void DownClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveDown();
    }
}