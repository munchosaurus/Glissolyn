using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.3f;
    public bool directionPossible;
    public bool isTalking;
    public LayerMask wallLayer;

    void Update() 
    {
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving && isWalkable(transform.position + Vector3.up))
                StartCoroutine(MovePlayer(Vector3.up));

            if (Input.GetKey(KeyCode.A) && !isMoving && isWalkable(transform.position + Vector3.left))
                StartCoroutine(MovePlayer(Vector3.left));

            if (Input.GetKey(KeyCode.S) && !isMoving && isWalkable(transform.position + Vector3.down))
                StartCoroutine(MovePlayer(Vector3.down));

            if (Input.GetKey(KeyCode.D) && !isMoving && isWalkable(transform.position + Vector3.right))
                StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;
        float elapsedTime = 0;
        originalPos = transform.position;
        targetPos = originalPos + direction;
        while (elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos) {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, wallLayer) != null) 
        {
            return false;
        }
        return true;
    }

    public void StopMovement()
    {
        isTalking = true;
    }

    public void StartMovement()
    {
        isTalking = false;
    }
}
