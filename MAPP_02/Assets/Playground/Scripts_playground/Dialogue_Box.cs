using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Box : MonoBehaviour
{
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image dialogueImage;

    private string[] dialogue;
    private int currentDialoguePart;

    /*
     * Updates what the dialogue will be, the image of the character talking, makes sure it starts from the beginning and activates the "Dialogue Box"-GameObject.
     * Parameters: dialogue - An array of strings, each string consisting of one part of the dialogue to be shown.
     *            sprite   - The dialogue sprite from the character that is talking.
     */
    public void UpdateDialogue(string[] dialogue, Sprite sprite)
    {
        this.dialogue = dialogue;
        currentDialoguePart = 0;
        dialogueImage.sprite = sprite; // Updates the sprite to be shown in the dialogue.
        dialogueText.text = dialogue[currentDialoguePart]; // Set the dialogue text to the first part of the dialogue.
        gameObject.SetActive(true); // Activate the GameObject that this script is attached to (which is the "Dialogue Box"-GameObject.
    }

    // Updates the dialogue text to show the next part of the dialogue. Or if the dialogue is over, deactivate the "Dialogue Box"-GameObject.
    public void NextDialoguePart()
    {
        currentDialoguePart++; // Increase the position in the dialogue we want to show to access the next part.

        if(currentDialoguePart >= dialogue.Length) // Check if the position exists
        {
            gameObject.SetActive(false); // If it doesnt, deactivate the Dialogue Box.
        }
        else // If it does
        {
            dialogueText.text = dialogue[currentDialoguePart]; // Set the dialogue text to be the next part of the dialogue.
        }
    }
}
