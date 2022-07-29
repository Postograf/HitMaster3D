using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EndWaypointMoveTransition : Transition
{
    [SerializeField] private float _distanceTreshold = 0.2f;

    private float _sqrDistanceTreshold;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _sqrDistanceTreshold = _distanceTreshold * _distanceTreshold;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NeedTransit = 
            (_agent.destination - transform.position).sqrMagnitude <= _sqrDistanceTreshold;
    }
}
