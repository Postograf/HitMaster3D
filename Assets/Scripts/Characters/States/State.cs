using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions; 

    public StateMachine StateMachine { get; protected set; }

    public virtual void Enter(StateMachine stateMachine)
    {
        if (!enabled)
        {
            StateMachine = stateMachine;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(StateMachine);
            }
        }
    }

    public virtual void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public virtual State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}