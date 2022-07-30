using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointMoveState : State
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override void Enter(StateMachine stateMachine)
    {
        _agent.enabled = true;

        var nextStage = Level.Instance.NextStage();
        if (nextStage != null)
        {
            _agent.SetDestination(nextStage.Start.position);
            stateMachine.Animator.SetTrigger("run");
        }

        base.Enter(stateMachine);
    }

    private void OnDisable()
    {
        _agent.enabled = false;
    }
}
