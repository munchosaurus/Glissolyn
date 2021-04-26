using UnityEngine;

public class Button_Menu : MonoBehaviour
{
    public void MenuClick()
    {
        GameObject ql = Game_Controller.GetQuestLog().gameObject;
        if (!ql.activeInHierarchy)
        {
            ql.SetActive(true);
        }
        else
        {
            ql.SetActive(false);
        }
    }
}
