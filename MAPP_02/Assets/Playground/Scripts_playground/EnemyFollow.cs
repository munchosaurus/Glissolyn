using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float maxDistance;
    [SerializeField] private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector2.Distance(target.position, transform.position);
        if(targetDistance < maxDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
       
    }


}
