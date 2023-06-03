using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> CurrentScoreChangedEvent;
    public event Action<int> BestScoreChangedEvent;

    public static ScoreCounter Instance { get; private set; }

    private int _score; 
    private int _bestScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt(GlobalConst.BEST_SCORE);
        BestScoreChangedEvent?.Invoke(_bestScore);
    }

    public int Score
    {
        get => _score;
        set
        {
            if (_score == value) return;

            _score = value;
            CurrentScoreChangedEvent.Invoke(_score);
            UpdateBestScore();         
        }

    }

    private void UpdateBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = (int)_score;
            BestScoreChangedEvent?.Invoke(_bestScore);
            SaveBestScore();
        }
    }

    

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(GlobalConst.BEST_SCORE, _bestScore);
        PlayerPrefs.Save();
    }
}
