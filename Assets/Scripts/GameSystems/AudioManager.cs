using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _takeLootSound;
    [SerializeField] private AudioClip _enemyKillSound;
    [SerializeField] private AudioClip _playerKilledSound;

    public enum Sound { Click, Shoot, PlayerKilled, EnemyKilled, Loot}

    private void OnEnable()
    {
        Loot.LootCollected += PlayLootCollectedSound;
        EnemyHealth.EnemyDied += PlaySoundOnEnemyDied;
    }

    private void OnDisable()
    {
        Loot.LootCollected -= PlayLootCollectedSound;
        EnemyHealth.EnemyDied -= PlaySoundOnEnemyDied;
    }

    private void PlayLootCollectedSound()
    {
        _audioSource.PlayOneShot(_takeLootSound);
    }

    private void PlaySoundOnEnemyDied()
    {
        _audioSource.PlayOneShot(_enemyKillSound);
    }

    public void PlaySFX(Sound sound)
    {
        AudioClip clip = null;

        switch(sound)
        {
            case Sound.Shoot:
                clip = _shootSound;
                break;
            case Sound.Click:
                clip = _clickSound;
                break;
            case Sound.PlayerKilled:
                clip = _playerKilledSound;
                break;
        }

        _audioSource.PlayOneShot(clip);
    }
}
