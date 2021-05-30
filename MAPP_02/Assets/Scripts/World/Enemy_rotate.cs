using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_rotate : MonoBehaviour
{
    [SerializeField] private GameObject rotationKnob;
    [SerializeField] float rotationCoolDown;
    [SerializeField] private LayerMask wallLayer; // Choose what layers the Character shouldn't be faced towards
    [SerializeField] private Animator zombieAnimator;
    [SerializeField] private Facing onlyFace;
    private List<Facing> availableDirections = new List<Facing>();
    private int facingIndex;
    private float timer;

    private void Start()
    {
        if (onlyFace != Facing.OFF)
        {
            availableDirections.Add(onlyFace);
            ChangeFacing(onlyFace);
        }
        else
        {
            SetAvailableDirections();
        }
        facingIndex = 0;
    }

    private void Update()
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            if (Vector3.Distance(transform.position, Game_Controller.GetPlayerInfo().transform.position) <= 1)
            {
                RotateToPlayer();
            }
            else if (timer > rotationCoolDown)
            {
                ChangeFacing(availableDirections[facingIndex]);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    private void RotateToPlayer()
    {
        Vector3 distance = Game_Controller.GetPlayerInfo().transform.position - transform.position;
        Debug.Log(distance);
        if (distance.Equals(Vector3.up))
        {
            ChangeFacing(Facing.UP);
        }
        else if (distance.Equals(Vector3.down))
        {
            ChangeFacing(Facing.DOWN);
        }
        else if(distance.Equals(Vector3.left))
        {
            ChangeFacing(Facing.LEFT);
        }
        else if(distance.Equals(Vector3.right))
        {
            ChangeFacing(Facing.RIGHT);
        }
    }

        // Changes position of the child object rotationKnob which will be used to detect players
    public void ChangeFacing(Facing direction) {
        switch (direction)
        {
            case Facing.UP:
                rotationKnob.transform.position = transform.position + Vector3.up;
                zombieAnimator.SetTrigger("faceUp");
                break;

            case Facing.LEFT:

                rotationKnob.transform.position = transform.position + Vector3.left;
                zombieAnimator.SetTrigger("faceLeft");
                break;

            case Facing.DOWN:

                rotationKnob.transform.position = transform.position + Vector3.down;
                zombieAnimator.SetTrigger("faceDown");
                break;

            case Facing.RIGHT:

                rotationKnob.transform.position = transform.position + Vector3.right;
                zombieAnimator.SetTrigger("faceRight");
                break;
        }
        facingIndex++;
        if(facingIndex >= availableDirections.Count)
        {
            facingIndex = 0;
        }
    }
        // Looks at the 4 tiles next to the Zombie in both X and Y directions to determine what directions the zombie should be able to face towards
    private void SetAvailableDirections() {
        if (Physics2D.OverlapCircle(transform.position + Vector3.up, 0.2f, wallLayer) == null)
        {
            availableDirections.Add(Facing.UP);
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.left, 0.2f, wallLayer) == null)
        {
            availableDirections.Add(Facing.LEFT);
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.down, 0.2f, wallLayer) == null)
        {
            availableDirections.Add(Facing.DOWN);
        }
        if (Physics2D.OverlapCircle(transform.position + Vector3.right, 0.2f, wallLayer) == null)
        {
            availableDirections.Add(Facing.RIGHT);
        }
    }

    public void resetFacing()
    {
        ChangeFacing(availableDirections[facingIndex]);
    }

    public void SetOnlyFace(Facing direction)
    {
        onlyFace = direction;
        availableDirections = new List<Facing>();
        availableDirections.Add(onlyFace);
        ChangeFacing(onlyFace);
    }
}

public enum Facing
{
    OFF,
    UP,
    DOWN,
    RIGHT,
    LEFT
}
