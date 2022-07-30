using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthContainer _healthContainer;
    [SerializeField] private Image _filling;

    private void Start()
    {
        _healthContainer.Damaged += OnDamaged;
        _healthContainer.Died += OnDeath;
    }

    private void OnDamaged(float health)
    {
        _filling.fillAmount = health / _healthContainer.MaxHealth;
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
