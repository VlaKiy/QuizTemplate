using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AnswerChecker _answerChecker;

    private int _score = 0;
    private int _lifePoints = 3;
    private int _reward = 1;
    private int _punishment = 1;

    public event Action OnAnsweredQuestion;
    public event Action OnLost;

    #region MonoBehaviour

    private void OnEnable()
    {
        _answerChecker.OnRightAnswered += AddScore;
        _answerChecker.OnWrongAnswered += TakeLifePoint;
    }

    private void OnDisable()
    {
        _answerChecker.OnRightAnswered -= AddScore;
        _answerChecker.OnWrongAnswered -= TakeLifePoint;
    }

    #endregion

    private void AddScore()
    {
        _score += _reward;

        OnAnsweredQuestion?.Invoke();
    }

    private void TakeLifePoint()
    {
        _lifePoints -= _punishment;

        OnAnsweredQuestion?.Invoke();

        if (_lifePoints < 0)
            OnLost?.Invoke();
    }
}
