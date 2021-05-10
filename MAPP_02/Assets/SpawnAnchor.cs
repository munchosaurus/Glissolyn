using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnchor : MonoBehaviour
{
    [SerializeField]private GameObject spawner;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //print("oii");
            collision.GetComponent<Player_Info>().SetSpawnPosition(spawner);
        }
    }

}
