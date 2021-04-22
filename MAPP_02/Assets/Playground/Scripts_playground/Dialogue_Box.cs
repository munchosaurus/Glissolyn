using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Box : MonoBehaviour
{
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image dialogueImage;

    private NPCMovement theMovementScript;
    private string[] dialogue;
    private string whosTalking;
    private int currentDialoguePart;
    private bool dialogueIsActive;

    /*
     * Updates what the dialogue will be, the image of the character talking, makes sure it starts from the beginning and activates the "Dialogue Box"-GameObject.
     * Parameters: dialogue - An array of strings, each string consisting of one part of the dialogue to be shown.
     *            sprite   - The dialogue sprite from the character that is talking.
     */
    public void UpdateDialogue(NPC_Info theNPC)
    {
        theMovementScript = theNPC.gameObject.GetComponent<NPCMovement>();
        Time.timeScale = 0;
        if(theMovementScript != null)
        {
            theMovementScript.StopMoving();
        }
        this.dialogue = theNPC.GetDialogue();
        this.whosTalking = theNPC.GetName();
        currentDialoguePart = 0;
        dialogueImage.sprite = theNPC.GetDialogueSprite(); // Updates the sprite to be shown in the dialogue.
        BuildDialogueText(); // Set the dialogue text to the first part of the dialogue.
        dialogueIsActive = true;
        gameObject.SetActive(true); // Activate the GameObject that this script is attached to (which is the "Dialogue Box"-GameObject.
    }

    // Updates the dialogue text to show the next part of the dialogue. Or if the dialogue is over, deactivate the "Dialogue Box"-GameObject.
    public bool NextDialoguePart()
    {
        if (dialogueIsActive)
        {
            currentDialoguePart++; // Increase the position in the dialogue we want to show to access the next part.

            if (currentDialoguePart >= dialogue.Length) // Check if the position exists
            {
                gameObject.SetActive(false); // If it doesnt, deactivate the Dialogue Box.
                dialogueIsActive = false;
                if (theMovementScript != null)
                {
                    theMovementScript.StartMoving(); // Allow the npc to start moving again.
                }
                GameObject.FindGameObjectWithTag("Character").GetComponent<Grid_movement>().StartMovement(); // Allow the player to start moving again;
                Time.timeScale = 1;
            }
            else // If it does
            {
                BuildDialogueText(); // Set the dialogue text to be the next part of the dialogue.
            }
        }

        return dialogueIsActive;
    }

    private void BuildDialogueText()
    {
        dialogueText.text = whosTalking + ": " + dialogue[currentDialoguePart];
    }
}
