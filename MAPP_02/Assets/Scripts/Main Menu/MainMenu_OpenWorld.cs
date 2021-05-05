using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_OpenWorld : MonoBehaviour
{
    public void StartPlaying() {
        SceneManager.LoadScene(1);
    }
}
