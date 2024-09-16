using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int CurrentScore { get; private set; }

    private void OnEnable()
    {
        EnemyHealth.EnemyDied += AddScore;
    }

    private void OnDisable()
    {
        EnemyHealth.EnemyDied -= AddScore;
    }

    private void AddScore()
    {
        CurrentScore++;
    }
}
