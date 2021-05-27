using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_movement : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private GameObject rotation;
    [SerializeField] private GameObject gridClaimer;
    [SerializeField] private Animator playerAnimator;

    private bool isMoving;
    private float timeToMove = 0.35f;
    private Vector3 originalPos;
    private bool shouldMove;
    private Vector3 currentFacing = Vector3.zero;
    private Vector3 direction = Vector3.zero;

    void Update() 
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            if (shouldMove && !isMoving)
            {
                StartCoroutine(MovePlayer(direction));
            }

            if (!isMoving && currentFacing != direction)
            {
                Rotate(direction);
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        if (IsWalkable(transform.position + direction)) {
            float elapsedTime = 0;
            originalPos = transform.position;
            if (direction == Vector3.up)
            {
                playerAnimator.SetTrigger("moveUp");
            }
            else if (direction == Vector3.down)
            {
                playerAnimator.SetTrigger("moveDown");
            }
            else if (direction == Vector3.right)
            {
                playerAnimator.SetTrigger("moveRight");
            }
            else if (direction == Vector3.left)
            {
                playerAnimator.SetTrigger("moveLeft");
            }
            isMoving = true;
            rotation.transform.position = transform.position + direction;
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPos, originalPos + direction, elapsedTime / timeToMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = originalPos + direction;
            currentFacing = Vector3.zero;
        }
        isMoving = false;
        gridClaimer.transform.parent = gameObject.transform;
        yield return 1;
    }

    private void Rotate(Vector3 direction) {

        if (direction == Vector3.up) {
            playerAnimator.SetTrigger("faceUp");
            
        }
        else if (direction == Vector3.down) {
            playerAnimator.SetTrigger("faceDown");
        }
        else if (direction == Vector3.right)
        {
            playerAnimator.SetTrigger("faceRight");
        }
        else if (direction == Vector3.left)
        {
            playerAnimator.SetTrigger("faceLeft");
        }
        currentFacing = direction;
        rotation.transform.position = transform.position + direction;
    }

    private bool IsWalkable(Vector3 targetPos) {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, wallLayer) != null) 
        {
            return false;
        }
        gridClaimer.transform.parent = null;
        gridClaimer.transform.position = targetPos;
        return true;
    }

    public bool GetMoving() {
        return isMoving;    
    }

    public Vector3 GetFacing()
    {
        return currentFacing;
    }

    public void MoveUp()
    {
        direction = Vector3.up;
        shouldMove = true;
    }

    public void MoveLeft()
    {
        direction = Vector3.left;
        shouldMove = true;
    }

    public void MoveRight()
    {
        direction = Vector3.right;
        shouldMove = true;
    }

    public void MoveDown()
    {
        direction = Vector3.down;
        shouldMove = true;
    }

    public void StopMoving()
    {
        shouldMove = false;
    }
}
