using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEditor;

using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _count;

    private List<Bullet> _pool;
    public static BulletSpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        _pool = new List<Bullet>();
        for (int i = 0; i < _count; i++)
        {
            var bullet = Instantiate(_prefab, transform);
            bullet.gameObject.SetActive(false);
            _pool.Add(bullet);
        }
    }

    public Bullet Get(Vector3 position, Vector3 direction, float speed)
    {
        var bullet = _pool.FirstOrDefault(b => b.gameObject.activeInHierarchy == false);

        if (bullet != null)
        {
            bullet.transform.position = position;
            bullet.gameObject.SetActive(true);
            bullet.Launch(direction, speed);
        }

        return bullet;
    }

    public void Return(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
