using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private void Start()
    {
        _scoreCounter.BestScoreChangedEvent += OnBestScoreChanged;
        _scoreCounter.CurrentScoreChangedEvent += OnCurrentScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.BestScoreChangedEvent -= OnBestScoreChanged;
        _scoreCounter.CurrentScoreChangedEvent -= OnCurrentScoreChanged;
    }

    private void OnBestScoreChanged(int _bestScore)
    {
        _bestScoreText.text = _bestScore.ToString();
    }
    private void OnCurrentScoreChanged(int _currentScore)
    {
        _currentScoreText.text = _currentScore.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
