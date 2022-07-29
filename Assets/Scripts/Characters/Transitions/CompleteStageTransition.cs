using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteStageTransition : Transition
{
    private Stage _currentStage;

    protected override void OnEnable()
    {
        base.OnEnable();

        _currentStage = Level.Instance.CurrentStage;
        NeedTransit = _currentStage.IsCompleted;

        _currentStage.Completed += OnStageCompletion;
    }

    private void OnStageCompletion()
    {
        NeedTransit = true;
    }

    private void OnDisable()
    {
        _currentStage.Completed -= OnStageCompletion;
    }
}
