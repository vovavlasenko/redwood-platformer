using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ScoreController _scoreController;

    public void OnGameOver()
    {
        _playerInput.DisableInput();
        _gameOverPanel.SetActive(true);
        _scoreText.SetText($"Score: {_scoreController.CurrentScore}");
        Time.timeScale = 0;
    }
 }
