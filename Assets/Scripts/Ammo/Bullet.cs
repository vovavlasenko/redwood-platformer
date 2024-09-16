using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage;

    public static event Action<GameObject> BulletCollides;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                damageable.TakeDamage(_bulletDamage);
            }
        }

        BulletCollides?.Invoke(gameObject);
    }
}
