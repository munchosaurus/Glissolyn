using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_ColorSelection : MonoBehaviour
{


    // Drag & drop slider
    public UnityEngine.UI.Slider slider;

    // Drag & drop handle
    public UnityEngine.UI.Image hair;

    Color[] colors = new Color[]
    {
        new Color(1, 0, 0),
        new Color(1, 1, 0),
        new Color(0, 1, 0),
        new Color(0, 1, 1),
        new Color(0, 0, 1),
        new Color(1, 0, 1)
    };

    public void Update()
    {

        hair.color = colors[(int)slider.value];
    }

}
