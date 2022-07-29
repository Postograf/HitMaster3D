using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(StartLevel);
    }

    private void StartLevel()
    {
        gameObject.SetActive(false);
        Level.Instance.State = LevelState.Started;
    }
}
