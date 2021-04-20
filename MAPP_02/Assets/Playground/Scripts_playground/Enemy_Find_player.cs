using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 position;
    [SerializeField] private float timeToMove = 0.5f;
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            
            if (!collision.GetComponent<Grid_movement>().GetMoving()) {

                Move(player.transform.position);
            }
            
            
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
            float elapsedTime = 0;
            Vector3 originalPos = transform.position;
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = direction;
    }

}
