using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_OpenWorld : MonoBehaviour
{
    [SerializeField] AudioThingy audioThingy;
    public void StartPlaying() {
        StartCoroutine(audioThingy.FadeOut());
    }
}
