using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider health;

    public void SetHP()
    {
        health.value =  health.maxValue;
    }
}
