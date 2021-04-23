using UnityEngine;

public class Button_Up : MonoBehaviour
{
    public void UpClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>().MoveUp();
    }
}
