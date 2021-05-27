using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Box : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image dialogueImage;

    private NPC_Info theNPCInfo;
    private string theName;
    private string[] theDialogue;
    private int currentDialoguePart;
    private bool npcIsTalking;

    /*
     * Updates what the dialogue will be, the image of the character talking, makes sure it starts from the beginning and activates the "Dialogue Box"-GameObject.
     * Parameters: theNPCInfo - A reference to what NPC is talking.
     */
    public void UpdateDialogue(NPC_Info theNPCInfo)
    {
        Game_Controller.SetPause(true);
        this.theNPCInfo = theNPCInfo;
        dialogueImage.sprite = theNPCInfo.GetDialogueSprite();
        theDialogue = theNPCInfo.GetDialogue();
        theName = theNPCInfo.GetName();
        npcIsTalking = true;
        currentDialoguePart = 0;
        BuildDialogueText(); // Set the dialogue text to the first part of the dialogue.
        gameObject.SetActive(true); // Activate the GameObject that this script is attached to (which is the "Dialogue Box"-GameObject.
    }

    public void UpdateDialogue(string[] dialogue)
    {
        dialogueImage.sprite = defaultSprite;
        npcIsTalking = false;
        theNPCInfo = null;
        theDialogue = dialogue;
        theName = "System";
        currentDialoguePart = 0;
        BuildDialogueText(); // Set the dialogue text to the first part of the dialogue.
        gameObject.SetActive(true); // Activate the GameObject that this script is attached to (which is the "Dialogue Box"-GameObject.
        Game_Controller.SetPause(true);
    }

    // Updates the dialogue text to show the next part of the dialogue. Or if the dialogue is over, deactivate the "Dialogue Box"-GameObject.
    public bool NextDialoguePart()
    {
        if (gameObject.activeInHierarchy)
        {
            currentDialoguePart++; // Increase the position in the dialogue we want to show to access the next part.

            if (currentDialoguePart >= theDialogue.Length) // Check if the position exists
            {
                gameObject.SetActive(false); // If it doesnt, deactivate the Dialogue Box.
                Game_Controller.SetPause(gameObject.activeInHierarchy);
                if (npcIsTalking)
                {
                    if (theNPCInfo.TryGetComponent<NPC_Movement>(out NPC_Movement npcmove)) // Check if the NPC has a NPC_Movement script and is not an enemy
                    {
                        npcmove.TurnBackToPreviousFacing(); // If it does then its not an enemy and we should make it turn back to where it was facing before.
                    } else if(theNPCInfo.TryGetComponent<Enemy_rotate>(out Enemy_rotate er))
                    {
                        er.resetFacing();
                    }
                    if (theNPCInfo.TryGetComponent<Enemy_Info>(out Enemy_Info eInfo))
                    {
                        Game_Controller.RunTransition();
                        Combat_Info.ChangeEnemy(eInfo);
                    }
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
        dialogueText.text = theName + ": " + InsertPlayerName(theDialogue[currentDialoguePart]); // Building a part of the dialogue like this "<Name of the speaker>: <Text>"
    }

    private string InsertPlayerName(string s)
    {
        return s.Replace("{playerName}", Game_Controller.GetPlayerName());
    }
}
