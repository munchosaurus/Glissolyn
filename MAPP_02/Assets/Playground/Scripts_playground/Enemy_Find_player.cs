using System.Collections;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private Transform directionObject;
    [SerializeField] private float timeToMove = 0.35f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float raycastLength;
    [SerializeField] private Animator zombieAnimator;
    private RaycastHit2D target;
    private bool shouldMove;

    private void Start()
    {
        shouldMove = true;
    }

    private void Update()
    {
        if(!target)
        {
            target = Physics2D.Raycast(transform.position, directionObject.localPosition, raycastLength, playerLayer);
        }
        else if (shouldMove)
        {
            shouldMove = false;
            print("Found target: " + target.transform.position);
            StartCoroutine(Move(target.transform.position - directionObject.transform.localPosition));
            gameObject.GetComponent<NPC_Info>().Interact();
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
            float elapsedTime = 0;
            Vector3 originalPos = transform.position;
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove * target.distance));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = direction;
    }
}
