using UnityEngine;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] private int _startAmmoAmount;
    [SerializeField] private TextMeshProUGUI _ammoAmountText;
    [SerializeField] private GameOverController _gameOverController;

    private int _currentAmmoAmount;

    private void Start()
    {
        ChangeBulletAmount(_startAmmoAmount);
    }

    public void ChangeBulletAmount(int amount)
    {
        _currentAmmoAmount += amount;
        _ammoAmountText.SetText($"Bullets: {_currentAmmoAmount}");
        CheckBulletAmount();
    }

    public void CheckBulletAmount()
    {
        if (_currentAmmoAmount <= 0)
        {
            _gameOverController.OnGameOver();
        }
    }
}
