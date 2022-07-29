using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        NeedTransit = Level.Instance.State == LevelState.Ended;

        Level.Instance.Ended += OnGameEnd;
    }

    private void OnGameEnd()
    {
        NeedTransit = true;
    }

    private void OnDisable()
    {
        Level.Instance.Ended -= OnGameEnd;
    }
}
