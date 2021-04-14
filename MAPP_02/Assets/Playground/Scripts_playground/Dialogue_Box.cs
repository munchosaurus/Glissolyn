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

    public void UpdateDialogue(string[] dialogue)
    {
        this.dialogue = dialogue;
        currentDialoguePart = 0;
        dialogueText.text = dialogue[currentDialoguePart];
        gameObject.SetActive(true);
    }

    public void UpdateDialogueImage(Sprite sprite)
    {
        dialogueImage.sprite = sprite;
    }

    public void NextDialoguePart()
    {
        currentDialoguePart++;

        if(currentDialoguePart >= dialogue.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            dialogueText.text = dialogue[currentDialoguePart];
        }
    }
}
