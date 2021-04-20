using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private Transform directionObject;
    [SerializeField] private float timeToMove = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int raycastLength;

    private int VECTOR_INVERSE_MULTIPLIER = -1;
    private RaycastHit2D target;
    private Vector3 raycastEnd;
    private Vector3 currentDirection;

    private void Update()
    {
        if(!target)
        {
            UpdateRaycastEnd(Vector3.zero + directionObject.localPosition);

            target = Physics2D.Raycast(transform.position, raycastEnd, playerLayer);
        }
        else
        {
            Move(target.collider.gameObject.transform.position - (currentDirection * VECTOR_INVERSE_MULTIPLIER));
        }
    }

    private void UpdateRaycastEnd(Vector3 direction)
    {
        if (direction != currentDirection)
        {
            raycastEnd = transform.position + direction * raycastLength;
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
            float elapsedTime = 0;
            Vector3 originalPos = transform.position;
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = direction;
    }
}
