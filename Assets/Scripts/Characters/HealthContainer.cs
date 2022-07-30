using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private bool _canRagdoll;

    private Animator _animator;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private Rigidbody _mainRigidbody;
    private Collider _mainCollider;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    public event UnityAction<float> Damaged;
    public event UnityAction Died;

    private void Awake()
    {
        CurrentHealth = MaxHealth;

        if (_canRagdoll)
        {
            _mainCollider = GetComponent<Collider>();
            _mainRigidbody = GetComponent<Rigidbody>();

            SetCollidersActive(false);
            SetRigidbodiesKinematic(true);
            _animator = GetComponent<Animator>();
            if (_animator != null)
                _animator.enabled = true;
        }
    }

    public void TakeDamage(float damage, Vector3 force, Vector3 from)
    {
        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Died?.Invoke();

            if (_canRagdoll)
                BecomeRegdoll(force, from);
            else
                Destroy(gameObject);
        }
            
        Damaged?.Invoke(CurrentHealth);
    }

    private void BecomeRegdoll(Vector3 force, Vector3 from)
    {
        SetCollidersActive(true);
        SetRigidbodiesKinematic(false);

        if (_animator != null)
            _animator.enabled = false;

        _rigidbodies
            .OrderBy(r => (r.position - from).sqrMagnitude)
            .First()
            .AddForceAtPosition(force, from, ForceMode.VelocityChange);
    }

    private void SetRigidbodiesKinematic(bool state)
    {
        if (_rigidbodies is null)
            _rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        if (_mainRigidbody != null)
            _mainRigidbody.isKinematic = !state;
    }

    private void SetCollidersActive(bool state)
    {
        if (_colliders is null)
            _colliders = GetComponentsInChildren<Collider>();

        foreach (var collider in _colliders)
        {
            collider.enabled = state;
        }

        if (_mainCollider != null)
            _mainCollider.enabled = !state;
    }
}
