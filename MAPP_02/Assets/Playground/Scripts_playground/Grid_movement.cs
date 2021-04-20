using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos;
    private float timeToMove = 0.3f;
    public bool directionPossible;
    public bool isTalking;
    public LayerMask wallLayer;
    public GameObject rotation;
    [SerializeField] private Animator playerAnimator;

    void Update() 
    {
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.up;
                playerAnimator.SetTrigger("facingUp");
                StartCoroutine(MovePlayer(rotation.transform.position));

            }

            if (Input.GetKey(KeyCode.A) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.left;
                playerAnimator.SetTrigger("facingLeft");
                StartCoroutine(MovePlayer(rotation.transform.position));

            }

            if (Input.GetKey(KeyCode.S) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.down;
                playerAnimator.SetTrigger("facingDown");
                StartCoroutine(MovePlayer(rotation.transform.position));

            }

            if (Input.GetKey(KeyCode.D) && !isMoving ) {
                rotation.transform.position = transform.position + Vector3.right;
                playerAnimator.SetTrigger("facingRight");
                StartCoroutine(MovePlayer(rotation.transform.position));

            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        float elapsedTime = 0;
        if (IsWalkable(direction))
        {
            isMoving = true;
            
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
        playerAnimator.SetTrigger("stopMoving");
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
