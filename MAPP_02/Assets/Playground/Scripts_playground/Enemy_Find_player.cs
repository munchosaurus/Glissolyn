using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private Transform directionObject;
    [SerializeField] private float timeToMove = 0.35f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float raycastLength;
    [SerializeField] private Material material;

    private RaycastHit2D target;
    private Vector3 raycastEnd;
    private Vector3 currentDirection;
    private bool shouldMove;

    private void Start()
    {
        raycastEnd = transform.position + Vector3.up;
        shouldMove = true;
    }

    private void Update()
    {
        if(!target)
        {
            target = Physics2D.Raycast(transform.position, directionObject.localPosition, raycastLength, playerLayer);
            print("no targer");
        }
        else if (shouldMove)
        {
            shouldMove = false;
            print("targer: " + target.transform.position);
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
    void DrawLine()
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = transform.position;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = material;
        lr.startColor = Color.white;
        lr.endColor = Color.white;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, raycastEnd);
        GameObject.Destroy(myLine, 2f);
    }
}
