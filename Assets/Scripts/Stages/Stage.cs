using System;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    [SerializeField] private Transform _start;

    public Transform Start => _start;
    public event Action Completed;

    private bool _isCompleted = false;
    public bool IsCompleted 
    { 
        get => _isCompleted; 
        protected set
        {
            _isCompleted = value;
            Completed?.Invoke();
        } 
    }
}