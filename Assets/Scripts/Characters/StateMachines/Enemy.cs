using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(HealthContainer))]
public class Enemy : StateMachine
{
    private HealthContainer _healthContainer;

    protected override void Awake()
    {
        Animator = GetComponent<Animator>();
        _healthContainer = GetComponent<HealthContainer>();
    }
}
