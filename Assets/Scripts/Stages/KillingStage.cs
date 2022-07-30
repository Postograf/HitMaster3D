using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingStage : Stage
{
    [SerializeField] private HealthContainer[] _targets;

    private int _targetsCount;

    private void Awake()
    {
        _targetsCount = _targets.Length;

        foreach (var target in _targets)
        {
            target.Died += OnTargetDied;
        }
    }

    private void OnTargetDied()
    {
        _targetsCount--;

        if (_targetsCount <= 0)
        {
            IsCompleted = true;
        }
    }
}
