using System.Collections;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private Transform directionObject;
    [SerializeField] private float timeToMove = 0.35f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float raycastLength;
    [SerializeField] private Animator zombieAnimator;
    private GameObject playerObject;
    private RaycastHit2D target;
    private bool shouldMove;

    private void Start()
    {
        shouldMove = true;
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if(!target)
        {
            target = Physics2D.Raycast(transform.position, directionObject.localPosition, raycastLength, playerLayer);
        }
        else if (shouldMove)
        {
            if (!playerObject.GetComponent<Grid_movement>().GetMoving()) {
                shouldMove = false;
                StartCoroutine(Move(target.transform.position - directionObject.transform.localPosition));
                gameObject.GetComponent<NPC_Info>().Interact();
            }
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        float elapsedTime = 0;
        Vector3 originalPos = transform.position;
        if (direction.x < transform.position.x)
        {
            zombieAnimator.SetTrigger("moveLeft");
        }
        else if (direction.x > transform.position.x)
        {
            zombieAnimator.SetTrigger("moveRight");
        }
        else if (direction.y < transform.position.y)
        {
            zombieAnimator.SetTrigger("moveDown");
        }
        else if (direction.y > transform.position.y)
        {
            zombieAnimator.SetTrigger("moveUp");
        }
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove * target.distance));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = direction;
    }
}
