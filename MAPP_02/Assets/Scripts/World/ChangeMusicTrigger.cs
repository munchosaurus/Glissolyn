using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicTrigger : MonoBehaviour
{
    [SerializeField] private int audioID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Game_Controller.GetDataBase().GetCurrentAudioID() != audioID)
            {
                collision.gameObject.GetComponent<Player_Info>().ChangeMusic(audioID);
                Game_Controller.GetDataBase().SetCurrentAudioID(audioID);
            }
        }
    }
}
