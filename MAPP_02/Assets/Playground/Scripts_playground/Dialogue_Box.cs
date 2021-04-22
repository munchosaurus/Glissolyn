using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Box : MonoBehaviour
{
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image dialogueImage;

    private NPC_Info theNPCInfo;
    private int currentDialoguePart;

    /*
     * Updates what the dialogue will be, the image of the character talking, makes sure it starts from the beginning and activates the "Dialogue Box"-GameObject.
     * Parameters: dialogue - An array of strings, each string consisting of one part of the dialogue to be shown.
     *            sprite   - The dialogue sprite from the character that is talking.
     */
    public void UpdateDialogue(NPC_Info theNPCInfo)
    {
        this.theNPCInfo = theNPCInfo;;
        dialogueImage.sprite = theNPCInfo.GetDialogueSprite();
        currentDialoguePart = 0;
        BuildDialogueText(); // Set the dialogue text to the first part of the dialogue.
        gameObject.SetActive(true); // Activate the GameObject that this script is attached to (which is the "Dialogue Box"-GameObject.
        Game_Controller.TogglePause(gameObject.activeInHierarchy);
    }

    // Updates the dialogue text to show the next part of the dialogue. Or if the dialogue is over, deactivate the "Dialogue Box"-GameObject.
    public bool NextDialoguePart()
    {
        if (gameObject.activeInHierarchy)
        {
            currentDialoguePart++; // Increase the position in the dialogue we want to show to access the next part.

            if (currentDialoguePart >= theNPCInfo.GetDialogue().Length) // Check if the position exists
            {
                gameObject.SetActive(false); // If it doesnt, deactivate the Dialogue Box.
                Game_Controller.TogglePause(gameObject.activeInHierarchy);
                if(theNPCInfo.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove)) // Check if the NPC has a NPC_Movement script
                {
                    npcmove.TurnBackToPreviousFacing(); // If it does then its not an enemy and we should make it turn back to where it was facing before.
                }
            }
            else // If it does
            {
                BuildDialogueText(); // Set the dialogue text to be the next part of the dialogue.
            }
        }

        return gameObject.activeInHierarchy;
    }

    private void BuildDialogueText()
    {
        dialogueText.text = theNPCInfo.GetName() + ": " + theNPCInfo.GetDialogue()[currentDialoguePart]; // Building a part of the dialogue like this "<Name of the speaker>: <Text>"
    }
}
