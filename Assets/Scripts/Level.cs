using System;

using UnityEngine;

public enum LevelState : short
{
    Preparation,
    Started,
    Ended
}

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Stage[] _stages;

    private int _currentStageIndex;
    private LevelState _state;

    public static Level Instance { get; private set; }
    public Stage CurrentStage => _stages[_currentStageIndex];
    public event Action Started;
    public event Action Ended;
    public LevelState State 
    {
        get => _state;
        set
        {
            _state = value;

            if (_state == LevelState.Started) 
                Started?.Invoke();
            else if (_state == LevelState.Ended)
                Ended?.Invoke();
        }
    }

    private void Awake()
    {
        Instance = this;

        if (_stages.Length > 0)
        {
            _currentStageIndex = 0;
            var currentStagePosition = CurrentStage.transform.position;
            Instantiate(_player, currentStagePosition, Quaternion.identity);
        }
    }

    public Stage NextStage()
    {
        if (CurrentStage.IsCompleted == false)
            return CurrentStage;

        if (_currentStageIndex + 1 >= _stages.Length)
        {
            State = LevelState.Ended;
            return null;
        }
        else
        {
            _currentStageIndex++;
        }

        return _stages[_currentStageIndex];
    }
}
