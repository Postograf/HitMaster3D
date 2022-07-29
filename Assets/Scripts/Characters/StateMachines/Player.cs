using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : StateMachine
{
    protected override void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        
        Player = this;
    }
}
