using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    private string text;

    public void Initialize(string title, string text, int id)
    {
        gameObject.name = "Quest Button#" + id;
        gameObject.GetComponentInChildren<Text>().text = title;
        this.text = text;
    }

    public void OnClick()
    {
        GameObject.Find("Quest Text Area").GetComponentInChildren<Text>().text = text;
    }
}
