using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 1.2f;
    private bool isTalking;

    void Update()
    {
        int movementNumber = randomNumber();
        if (movementNumber == 5 && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (movementNumber == 50 && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (movementNumber == 100 && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (movementNumber == 150 && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));

    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        originalPos = transform.position;
        targetPos = originalPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private int randomNumber() {
        int number = Random.Range(1, 1000);
        return number;
    }

    private void talking() { 
        
    }
   
}