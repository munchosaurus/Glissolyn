using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    [SerializeField] private float timeToMove;
    [SerializeField] private GameObject gridClaimer;
    [SerializeField] private int walkCDLow;
    [SerializeField] private int walkCDHigh;
    [SerializeField] private int maximumDistance;
    [SerializeField] private bool isEnemy;
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private Vector3 facing;
    public LayerMask blockingLayer;
    private GameObject player;
    private float walkCooldown;
    private float walkTimer;
    private Vector3 spawnPos;
    

    private void Start()
    {
        player = Game_Controller.GetPlayerInfo().gameObject;
    }

    void Update()
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            
            if (Vector3.Distance(player.transform.position, transform.position) <= 20f && walkTimer >= walkCooldown && !isMoving)
            {
                
                List<int> bannedNumbers = new List<int>();
                int movementNumber;
                do
                {
                    movementNumber = Random.Range(0, 4);
                    if (!IsWalkable(transform.position + GetDirection(movementNumber)))
                    {
                        bannedNumbers.Add(movementNumber);
                    }
                } while (bannedNumbers.Contains(movementNumber) && bannedNumbers.Count < 4);

                if(bannedNumbers.Count >= 4)
                {
                    walkTimer = 0;
                    walkCooldown = 5;
                }

                Vector3 direction = GetDirection(movementNumber);
                if (IsWalkable(transform.position + direction) && Vector3.Distance(transform.position + direction, spawnPos) <= maximumDistance)
                {
                    StartCoroutine(Move(direction));
                    gridClaimer.transform.parent = null;
                    gridClaimer.transform.position = transform.position + direction;
                    if (isEnemy)
                    {
                        transform.Find("Rotation_direction").transform.position = gridClaimer.transform.position;
                    }
                    
                    walkCooldown = Random.Range(walkCDLow, walkCDHigh);
                    walkTimer = 0;
                }
            }
            else
            {
                walkTimer += Time.deltaTime;
            }
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        AnimateMovement(direction);
        originalPos = transform.position;
        targetPos = originalPos + direction;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        gridClaimer.transform.position = transform.position;
        gridClaimer.transform.parent = gameObject.transform;
        AnimateRotation(direction);
    }

    private Vector3 GetDirection(int i)
    {
        switch (i)
        {
            case 0:
                return Vector3.up;
            case 1:
                return Vector3.left;
            case 2:
                return Vector3.right;
            case 3:
                return Vector3.down;
            default:
                return Vector3.zero;
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, blockingLayer) != null)
        {
            return false;
        }
        
        return true;
    }

    public void AnimateMovement(Vector3 direction) {
        if (direction == Vector3.up)
        {
            npcAnimator.SetTrigger("moveUp");
        }
        else if (direction == Vector3.down)
        {
            npcAnimator.SetTrigger("moveDown");
        }
        else if (direction == Vector3.right)
        {
            npcAnimator.SetTrigger("moveRight");
        }
        else if (direction == Vector3.left)
        {
            npcAnimator.SetTrigger("moveLeft");
        }

        facing = direction;
    }

    public void AnimateRotation(Vector3 direction) {
        if (direction == Vector3.up)
        {
            npcAnimator.SetTrigger("faceUp");
        }
        else if (direction == Vector3.down)
        {
            npcAnimator.SetTrigger("faceDown");
        }
        else if (direction == Vector3.right)
        {
            npcAnimator.SetTrigger("faceRight");
        }
        else if (direction == Vector3.left)
        {
            npcAnimator.SetTrigger("faceLeft");
        }
   }

    public void TurnToPlayer(Vector3 playerFacing) {
        AnimateRotation(-playerFacing);
    }

    public void TurnBackToPreviousFacing()
    {
        if (!isMoving)
        {
            AnimateRotation(facing);
        }
        else
        {
            AnimateMovement(facing);
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public void SetSpawnPos(Vector3 spawnPos)
    {
        this.spawnPos = spawnPos;
    }
}