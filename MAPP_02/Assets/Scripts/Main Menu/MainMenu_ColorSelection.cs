 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_ColorSelection : MonoBehaviour
{
    public bool hairGray;
    public int playerColor;

    // Drag & drop slider
    public UnityEngine.UI.Slider slider;

    // Drag & drop handle
    public UnityEngine.UI.Image playerImageBlue;
    public UnityEngine.UI.Image playerImageGray;

    public void Start()
    {
        playerColor = 0;
    }

    public void Update()
    {
        if(slider.value > 0)
        {
            playerColor = 0;
            playerImageBlue.enabled = false;
            playerImageGray.enabled = true;
            hairGray = true;
        } else
        {
            playerColor = 1;
            playerImageGray.enabled = false;
            playerImageBlue.enabled = true;
            hairGray = false;
        }

        Game_Controller.SetPlayerColor(playerColor);

    }
}
