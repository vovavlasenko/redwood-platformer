using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameOverController _gameOverController;

    public void TakeDamage(int value)
    {
        Die();
    }

    public void Die()
    {
        _audioManager.PlaySFX(AudioManager.Sound.PlayerKilled);
        _gameOverController.OnGameOver();
    }



}
