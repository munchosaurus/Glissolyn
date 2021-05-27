using System.Collections;
using UnityEngine;

public class Enemy_Find_player : MonoBehaviour
{
    [SerializeField] private Transform directionObject;
    [SerializeField] private float timeToMove = 0.35f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float raycastLength;
    [SerializeField] private Animator zombieAnimator;
    private Grid_movement playerMovement;
    private bool timerActive;
    private float timer;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Grid_movement>();       
    }

    private void Update()
    {
        if (!Game_Controller.IsGamePaused() && !Game_Controller.IsCombatActive())
        {
            RaycastHit2D target = Physics2D.Raycast(transform.position, directionObject.localPosition, raycastLength, playerLayer);
            if (timer <= 0 && target)
            {
                playerMovement.StopMoving();
                if (!playerMovement.GetMoving())
                {
                    Game_Controller.SetPause(true);
                    StartCoroutine(Move(target.transform.position - directionObject.transform.localPosition, target.distance));
                    gameObject.GetComponent<NPC_Info>().Interact();
                    timer = 5;
                }
            }
            else if (timerActive)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timerActive = false;
                }
            }
        }
    }

    private IEnumerator Move(Vector3 direction, float distance)
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
            transform.position = Vector3.Lerp(originalPos, direction, (elapsedTime / timeToMove * distance));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = direction;
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StartTimer(int timer)
    {
        this.timer = timer;
        timerActive = true;
    }
}
