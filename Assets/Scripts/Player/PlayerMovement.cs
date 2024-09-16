using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _horizontalMovement;
    private bool _isFacingRight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _isFacingRight = true;
    }

    private void Update()
    {
        if (_horizontalMovement != 0)
        {
            CheckDirection();

            _animator.SetBool("IsMoving", true);
        }

        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void CheckDirection()
    {
        if ((_horizontalMovement > 0 && !_isFacingRight) || (_horizontalMovement < 0 && _isFacingRight))
            Turn();
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        _isFacingRight = !_isFacingRight;
    }

    private void FixedUpdate()
    {
        Move();   
    }

    private void Move()
    {
        float targetSpeed = _horizontalMovement * _playerData.RunMaxSpeed; // Целевая (максимальная) скорость

        // Ускорение/замедление
        float accelRate = Mathf.Abs(targetSpeed) > 0.01f ? _playerData.RunAccelAmount : _playerData.RunDeccelAmount;

        // Разница между текущей скоростью и желаемой
        float speedDif = targetSpeed - _rigidbody.velocity.x;

        float movement = speedDif * accelRate;

        _rigidbody.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    public void GetMovementInput(float movementInput)
    {
        _horizontalMovement = movementInput;
    }



}


