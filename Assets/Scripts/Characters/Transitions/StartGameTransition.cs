using UnityEngine;

public class StartGameTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        Level.Instance.Started += StartMove;
    }

    private void StartMove()
    {
        NeedTransit = true;
    }

    private void OnDisable()
    {
        Level.Instance.Started -= StartMove;
    }
}
