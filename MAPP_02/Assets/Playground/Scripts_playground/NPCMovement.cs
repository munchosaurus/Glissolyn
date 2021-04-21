using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.7f;
    private bool isTalking;
    public LayerMask blockingLayer;
    public GameObject player;


    void Update()
    {
        if (!isTalking)
        {
            int movementNumber = randomNumber();
            if (Vector3.Distance(player.transform.position, transform.position) <= 20f)
            {
                if (movementNumber == 5 && !isMoving && (isWalkable(transform.position + Vector3.up)))
                    StartCoroutine(Move(Vector3.up));

                if (movementNumber == 50 && !isMoving && (isWalkable(transform.position + Vector3.left)))
                    StartCoroutine(Move(Vector3.left));

                if (movementNumber == 100 && !isMoving && (isWalkable(transform.position + Vector3.down)))
                    StartCoroutine(Move(Vector3.down));

                if (movementNumber == 150 && !isMoving && (isWalkable(transform.position + Vector3.right)))
                    StartCoroutine(Move(Vector3.right));
            }
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        originalPos = transform.position;
        AnimateMovement(direction);
        targetPos = originalPos + direction;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        AnimateRotation(direction);
    }

    private int randomNumber() {
        int number = Random.Range(1, 500);
        return number;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, blockingLayer) != null)
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

    public void AnimateMovement(Vector3 direction) {
        if (direction == Vector3.up)
        {
            npcAnimator.SetTrigger("moveUp");
        }
        else if (direction == Vector3.down)
        {
            npcAnimator.SetTrigger("moveDown");
        }
        else if (direction == Vector3.right)
        {
            npcAnimator.SetTrigger("moveRight");
        }
        else if (direction == Vector3.left)
        {
            npcAnimator.SetTrigger("moveLeft");
        }
    }

    public void AnimateRotation(Vector3 direction) {
        if (direction == Vector3.up)
        {
            npcAnimator.SetTrigger("faceUp");
        }
        else if (direction == Vector3.down)
        {
            npcAnimator.SetTrigger("faceDown");
        }
        else if (direction == Vector3.right)
        {
            npcAnimator.SetTrigger("faceRight");
        }
        else if (direction == Vector3.left)
        {
            npcAnimator.SetTrigger("faceLeft");
        }
   }

    public void TurnToPlayer(Vector3 direction) {
        if (direction.x < transform.position.x)
        {
            npcAnimator.SetTrigger("faceLeft");
        }
        else if (direction.x > transform.position.x)
        {
            npcAnimator.SetTrigger("faceRight");
        }
        else if (direction.y < transform.position.y)
        {
            npcAnimator.SetTrigger("faceDown");
        }
        else if (direction.y > transform.position.y)
        {
            npcAnimator.SetTrigger("faceUp");
        }
    }
}