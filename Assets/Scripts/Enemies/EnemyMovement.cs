using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private Vector3 _movingDirection;

    public void SetDirection(Vector3 playerPosition)
    {
        _movingDirection = (playerPosition - transform.position).normalized;
        _movingDirection.y = 0;
        CheckFlip();
    }

    private void CheckFlip()
    {
        if (_movingDirection.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale *= new Vector2(-1, 1);
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.Translate(_movingDirection * _speed * Time.deltaTime);
    }
}
