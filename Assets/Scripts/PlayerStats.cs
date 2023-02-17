using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AnswerChecker _answerChecker;

    private int _score = 0;
    private int _reward = 1;

    public event Action OnAnsweredQuestion;

    #region MonoBehaviour

    private void OnEnable()
    {
        _answerChecker.OnRightAnswered += AddScore;
    }

    private void OnDisable()
    {
        _answerChecker.OnRightAnswered -= AddScore;
    }

    #endregion

    private void AddScore()
    {
        _score += _reward;

        OnAnsweredQuestion?.Invoke();
    }
}