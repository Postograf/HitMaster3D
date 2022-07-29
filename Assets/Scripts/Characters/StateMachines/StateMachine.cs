using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] protected State _firstState;
    
    public State CurrentState { get; protected set; }
    public Rigidbody Rigidbody { get; protected set; }
    public Animator Animator { get; protected set; }
    static public Player Player { get; protected set; }

    protected abstract void Awake();

    protected void Start()
    {
        CurrentState = _firstState;
        CurrentState.Enter(this);
    }

    protected void Update()
    {
        if (CurrentState == null)
            return;

        var nextState = CurrentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    protected void Transit(State nextState)
    {
        CurrentState?.Exit();

        CurrentState = nextState;

        CurrentState?.Enter(this);
    }
}
