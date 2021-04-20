using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_movement : MonoBehaviour
{
    private bool isMoving;
    private float timeToMove = 0.35f;
    private Vector3 originalPos;
    public bool directionPossible;
    public bool isTalking;
    public LayerMask wallLayer;
    public GameObject rotation;
    [SerializeField] private Animator playerAnimator;
    private Vector3 currentFacing;
    private Vector3 direction;

    void Update() 
    {
        if (!isTalking)
        {   
            if (Input.GetKey(KeyCode.W) && !isMoving) {
                direction = Vector3.up;
                StartCoroutine(MovePlayer());
            }

            else if (Input.GetKey(KeyCode.A) && !isMoving) {
                direction = Vector3.left;
                StartCoroutine(MovePlayer());
            }

            else if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                direction = Vector3.right;
                StartCoroutine(MovePlayer());
            }

            else if (Input.GetKey(KeyCode.S) && !isMoving) {
                direction = Vector3.down;
                StartCoroutine(MovePlayer());
            }

            if (!isMoving && currentFacing != direction) {
                Rotate(direction);
            }
        }
    }

    private IEnumerator MovePlayer() {
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
        //playerAnimator.SetTrigger("stopMoving");
        currentFacing = direction;
        rotation.transform.position = transform.position + direction;
    }

    private bool IsWalkable(Vector3 targetPos) {
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

    public bool GetMoving() {
        return isMoving;    
    }

}
