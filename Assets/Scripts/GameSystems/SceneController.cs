using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnButtonClick);
        _quitButton.onClick.AddListener(OnButtonClick);
        _restartButton.onClick.AddListener(Restart);
        _quitButton.onClick.AddListener(Quit);
    }

    public void Restart()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnButtonClick()
    {
        _audioManager.PlaySFX(AudioManager.Sound.Click);
    }
}
