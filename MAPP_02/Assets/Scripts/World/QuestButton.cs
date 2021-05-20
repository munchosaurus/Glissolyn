using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    private string text;

    /*
     * Set up the information required in the "Quest Button"-GameObject for the quest log to work.
     * Parameters: title - The title of the quest.
     *            text  - The quest text.
     *            id    - The quest ID.
     */
    public void Initialize(Quest quest)
    {
        gameObject.name = "Quest Button#" + quest.GetQuestID(); // Change the name of GameObject.
        gameObject.GetComponentInChildren<Text>().text = quest.GetQuestTitle(); // Change the text displayed on the button.
        this.text = quest.GetQuestText(); // Remember the quest text to display in the information part of the quest log when the button is clicked.
        quest.SetButton(this);
    }

    // Called when the "Quest Button"-GameObject is clicked.
    public void OnClick()
    {
        Game_Controller.GetQuestLog().gameObject.transform.Find("Quest Text Area").GetComponentInChildren<Text>().text = text; // Find the "Quest Text Area"-GameObject in the active scene and then find the Text-Component on one of its children. 
                                                                                                                               // It works since there is only one child with a Text-component.
                                                                                                                               // Change that Text-components text to the questText from the Quest which this button represents.
        Game_Controller.GetQuestLog().SetCurrentOpenQuestButton(this);
    }

    public void UpdateQuestText(string text)
    {
        this.text = text;
    }
}
