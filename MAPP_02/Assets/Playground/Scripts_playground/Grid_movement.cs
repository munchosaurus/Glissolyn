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
    public GameObject rotation;
    void Update() 
    {
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.up;
                StartCoroutine(MovePlayer(rotation.transform.position));
            }

            if (Input.GetKey(KeyCode.A) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.left;
                StartCoroutine(MovePlayer(rotation.transform.position));
            }

            if (Input.GetKey(KeyCode.S) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.down;
                StartCoroutine(MovePlayer(rotation.transform.position));
            }

            if (Input.GetKey(KeyCode.D) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.right;
                StartCoroutine(MovePlayer(rotation.transform.position));
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        if (isWalkable(direction)) {
            isMoving = true;
            float elapsedTime = 0;
            originalPos = transform.position;
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = direction;

            isMoving = false;
        }

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
