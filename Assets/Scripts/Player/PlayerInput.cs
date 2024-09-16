using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;

    private bool _inputEnabled = true;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if (_inputEnabled)
        {
            _playerMovement.GetMovementInput(Input.GetAxisRaw("Horizontal"));
            _playerShooting.GetShootingInput(Input.GetKey(KeyCode.Space));
        }
    }

    public void DisableInput()
    {
        _inputEnabled = false;
    }
}
