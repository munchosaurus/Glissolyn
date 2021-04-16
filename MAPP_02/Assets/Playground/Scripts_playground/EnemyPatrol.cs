using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
   
    [SerializeField] private float speed;
    private float timeLeft;
    [SerializeField] private float timer;

    private GameObject nextTarget;
    // Start is called before the first frame update
    void Start()
    {
        nextTarget = point1;
        timeLeft = timer;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(nextTarget);

        if (gameObject.transform.position == nextTarget.transform.position)
        {
            if (timeLeft <= 0)
            {
                ChangeDirection();
                timeLeft = timer;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
        
    }

    private void MoveTo(GameObject target)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
       // if(gameObject.transform.position == target.transform.position)
       // {
            
        //}
    }

    private void ChangeDirection()
    {
        if(nextTarget == point1)
        {
            nextTarget = point2;
        }
        else
        {
            nextTarget = point1;
        }
    }

   
}
