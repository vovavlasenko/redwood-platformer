using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                damageable.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
