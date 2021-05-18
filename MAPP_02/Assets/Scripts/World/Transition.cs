using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;

    public void RunTransition()
    {
        transition.SetTrigger("Start");
    }

    public void RunTransitionEnd()
    {
        transition.SetTrigger("End");
        print("End");
    }
}
