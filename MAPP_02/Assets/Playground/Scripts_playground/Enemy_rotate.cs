using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_rotate : MonoBehaviour
{
    [SerializeField] private GameObject rotationKnob;
    [SerializeField] float rotationCoolDown;
    [SerializeField] private int startingDirection; // Choose which direction you want the zombie to start with by choosing 0-3'
    [SerializeField] private LayerMask wallLayer; // Choose what layers the Character shouldn't be faced towards
    [SerializeField] private Animator zombieAnimator;
    private bool[] availableDirections = new bool[4];
    private int directionIndex;
    private float timer;

    private void Start()
    {
        // Looks at what directions that should be iterable based upon the chosen layers in wallLayer
        SetAvailableDirections();
        // Sets the starting direction for the zombie
        directionIndex = startingDirection;
    }

    private void Update()
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            if (timer > rotationCoolDown)
            {
                ChangeFacing(directionIndex);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }


        // Changes position of the child object rotationKnob which will be used to detect players
    private void ChangeFacing(int i) {
        if (availableDirections[i] || i > availableDirections.Length)
        {
            switch (i)
            {
                case 0:
                    rotationKnob.transform.position = transform.position + Vector3.up;
                    zombieAnimator.SetTrigger("faceUp");
                    break;

                case 1:

                    rotationKnob.transform.position = transform.position + Vector3.left;
                    zombieAnimator.SetTrigger("faceLeft");
                    break;

                case 2:

                    rotationKnob.transform.position = transform.position + Vector3.down;
                    zombieAnimator.SetTrigger("faceDown");
                    break;

                case 3:

                    rotationKnob.transform.position = transform.position + Vector3.right;
                    zombieAnimator.SetTrigger("faceRight");
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
        // Looks at the 4 tiles next to the Zombie in both X and Y directions to determine what directions the zombie should be able to face towards
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

