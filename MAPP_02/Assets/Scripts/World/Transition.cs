using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;
    //Game_Controller.set

    private void Start()
    {
        Game_Controller.SetTransition(gameObject);
        
    }


    public void RunTransition()
    {
        transition.SetTrigger("Start");

        
        print("run");
    }

    public void RunTransitionEnd()
    {
        transition.SetTrigger("End");

        print("RUN2");
    }


}
