using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : StateMachine
{
    protected override void Awake()
    {
        Animator = GetComponent<Animator>();
        
        Player = this;
    }
}
