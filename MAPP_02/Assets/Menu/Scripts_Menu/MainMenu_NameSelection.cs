using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_NameSelection : MonoBehaviour
{
    public string playerName;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject inputFieldToDisable;
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private GameObject enterButtonToHide;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private Button enterButton;


    private void Update()
    {
        if (inputField.GetComponent<Text>().text.Length < 1)
        {
            enterButton.interactable = false;
        }
        else enterButton.interactable = true;
        
    }

    //Sets the playername in the welcome screen and displays the ENTER WORLD button
    public void SetName() {
        playerName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + playerName + "! " +
            "Press ENTER WORLD to start exploring the world of Glyssolin!";
        inputFieldToDisable.SetActive(false);
        enterButtonToHide.SetActive(false);
        startGameButton.SetActive(true);
        Game_Controller.SetPlayerName(playerName);

    }

}
