using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    private void OnEnable()
    {
        StateMachine.Animator.SetTrigger("setup");
    }
}
