using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LootSpawner))]
public class EnemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _healthBarImage;

    public static event Action EnemyDied;

    private float _currentHealth;
    private LootSpawner _lootSpawner;

    private void Awake()
    {
        _lootSpawner = GetComponent<LootSpawner>();    
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        UpdateHealthBar();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        _healthBarImage.fillAmount = _currentHealth / _maxHealth;

        if (_healthBarImage.fillAmount > 0.7)
        {
            _healthBarImage.color = Color.green;
        }

        else if (_healthBarImage.fillAmount < 0.35)
        {
            _healthBarImage.color = Color.red;
        }

        else
        {
            _healthBarImage.color = Color.yellow;
        }
    }

    public void Die()
    {
        EnemyDied?.Invoke();
        _lootSpawner.SpawnLoot();
        Destroy(gameObject);
    }



}
