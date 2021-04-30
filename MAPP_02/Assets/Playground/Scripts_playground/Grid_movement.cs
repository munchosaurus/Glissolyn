using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_movement : MonoBehaviour
{
<<<<<<< HEAD
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.3f;
=======
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private GameObject rotation;
    [SerializeField] private Animator playerAnimator;

    private bool isMoving;
    private float timeToMove = 0.35f;
    private Vector3 originalPos;
    private bool shouldMove;
    private Vector3 currentFacing = Vector3.zero;
    private Vector3 direction = Vector3.zero;
>>>>>>> Main

    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));

    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;
        float elapsedTime = 0;
        originalPos = transform.position;
        targetPos = originalPos + direction;
=======
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            /*if (Input.GetKey(KeyCode.W) && !isMoving) {
                direction = Vector3.up;
                StartCoroutine(MovePlayer(direction));
            }

            else if (Input.GetKey(KeyCode.A) && !isMoving) {
                direction = Vector3.left;
                StartCoroutine(MovePlayer(direction));
            }

            else if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                direction = Vector3.right;
                StartCoroutine(MovePlayer(direction));
            }

            else if (Input.GetKey(KeyCode.S) && !isMoving) {
                direction = Vector3.down;
                StartCoroutine(MovePlayer(direction));
            }

            if (!isMoving && currentFacing != direction) {
                Rotate(direction);
            }*/
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
>>>>>>> Main

        while (elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

<<<<<<< HEAD
        isMoving = false;
=======
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
>>>>>>> Main
    }
}
