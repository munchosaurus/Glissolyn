using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;

    public void RunTransition()
    {
        transition.SetTrigger("start");
    }


}
