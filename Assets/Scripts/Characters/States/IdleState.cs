using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private void OnEnable()
    {
        StateMachine.Animator.SetTrigger("setup");
    }

    private void Update()
    {
        
    }
}
