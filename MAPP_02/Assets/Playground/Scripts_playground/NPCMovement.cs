using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 1.2f;
    private bool isTalking;
    public LayerMask wallLayer;
    public GameObject player;

    void Update()
    {
        if (!isTalking)
        {
            int movementNumber = randomNumber();
            if (Vector3.Distance(player.transform.position, transform.position) <= 20f)
            {
                if (movementNumber == 5 && !isMoving && (isWalkable(transform.position + Vector3.up)))
                    StartCoroutine(MovePlayer(Vector3.up));

                if (movementNumber == 50 && !isMoving && (isWalkable(transform.position + Vector3.left)))
                    StartCoroutine(MovePlayer(Vector3.left));

                if (movementNumber == 100 && !isMoving && (isWalkable(transform.position + Vector3.down)))
                    StartCoroutine(MovePlayer(Vector3.down));

                if (movementNumber == 150 && !isMoving && (isWalkable(transform.position + Vector3.right)))
                    StartCoroutine(MovePlayer(Vector3.right));
            }
        }
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
        int number = Random.Range(1, 500);
        return number;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, wallLayer) != null)
        {
            return false;
        }
        return true;
    }

    public void StopMoving()
    {
        isTalking = true;
    }

    public void StartMoving()
    {
        isTalking = false;
    }
}