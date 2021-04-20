using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_rotate : MonoBehaviour
{
    [SerializeField] private GameObject rotationKnob;
    [SerializeField] float rotationCoolDown;
    private int directionIndex;
    private float timer;
    [SerializeField] private int startingDirection; // Choose which direction you want the zombie to start with by choosing 0-3'
    [SerializeField] private LayerMask wallLayer; // Choose what layers the Enemy shouldn't be faced towards
    [SerializeField] private bool[] availableDirections = new bool[4];

    private void Start()
    {
        //Looks at what directions that should be iterable based upon the chosen layers in wallLayer
        SetAvailableDirections();
        directionIndex = startingDirection;

        
    }

    private void Update()
    {
        if (timer > rotationCoolDown)
        {
            ChangeFacing(directionIndex);
            timer = 0;
        }
        else {
            timer += Time.deltaTime;
        }
        
    }

    private void ChangeFacing(int i) {
        if (availableDirections[i] || i > 3)
        {
            switch (i)
            {
                case 0:
                    rotationKnob.transform.position = transform.position + Vector3.up;
                    break;

                case 1:

                    rotationKnob.transform.position = transform.position + Vector3.left;
                    break;

                case 2:

                    rotationKnob.transform.position = transform.position + Vector3.down;
                    break;

                case 3:

                    rotationKnob.transform.position = transform.position + Vector3.right;
                    break;
            }
            directionIndex = i+1;
            if (directionIndex > 3)
            {
                directionIndex = 0;
            }
            
        }
        else {
            ChangeFacing(i + 1);
        }
    }

    private void SetAvailableDirections() {
        if (Physics2D.OverlapCircle(transform.position + Vector3.up, 0.2f, wallLayer) != null)
        {
            availableDirections[0] = false;
        }
        else {
            availableDirections[0] = true;    
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.left, 0.2f, wallLayer) != null)
        {
            availableDirections[1] = false;
        }
        else
        {
            availableDirections[1] = true;
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.down, 0.2f, wallLayer) != null)
        {
            availableDirections[2] = false;
        }
        else
        {
            availableDirections[2] = true;
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.right, 0.2f, wallLayer) != null)
        {
            availableDirections[3] = false;
        }
        else
        {
            availableDirections[3] = true;

        }
    }
}

