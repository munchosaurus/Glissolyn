using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    [SerializeField] private int maximumNumberToRandomize;
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    [SerializeField] private float timeToMove;
    private Vector3 facing;
    public LayerMask blockingLayer;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            int movementNumber = randomNumber();
            if (Vector3.Distance(player.transform.position, transform.position) <= 20f)
            {
                if (movementNumber == 5 && !isMoving && (isWalkable(transform.position + Vector3.up)))
                    StartCoroutine(Move(Vector3.up));

                if (movementNumber == 10 && !isMoving && (isWalkable(transform.position + Vector3.left)))
                    StartCoroutine(Move(Vector3.left));

                if (movementNumber == 15 && !isMoving && (isWalkable(transform.position + Vector3.down)))
                    StartCoroutine(Move(Vector3.down));

                if (movementNumber == 20 && !isMoving && (isWalkable(transform.position + Vector3.right)))
                    StartCoroutine(Move(Vector3.right));
            }
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        AnimateMovement(direction);
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
        AnimateRotation(direction);
    }

    private int randomNumber() {
        int number = Random.Range(1, maximumNumberToRandomize);
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

        facing = direction;
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

    public void TurnToPlayer(Vector3 playerFacing) {
        AnimateRotation(-playerFacing);
    }

    public void TurnBackToPreviousFacing()
    {
        if (!isMoving)
        {
            AnimateRotation(facing);
        }
        else
        {
            AnimateMovement(facing);
        }
    }
}