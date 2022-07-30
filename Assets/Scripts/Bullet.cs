using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _damage;

    private float _lifeTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _lifeTime = 0;
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;

        if (_lifeTime >= _maxLifeTime)
        {
            BulletSpawner.Instance.Return(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<HealthContainer>(out var health))
        {
            health.TakeDamage(_damage);
        }

        BulletSpawner.Instance.Return(this);
    }

    public void Launch(Vector3 direction, float speed)
    {
        transform.forward = direction;
        _rigidbody.velocity = direction * speed;
    }
}
