using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AnswerChecker _answerChecker;

    private int _score = 0;
    private int _reward = 1;

    public int Score => _score;

    public event Action OnAnsweredQuestion;

    #region MonoBehaviour

    private void OnEnable()
    {
        _answerChecker.OnRightAnswered += AddScore;
        _answerChecker.OnRightAnswered += InvokeAnsweredQuestionEvent;
        _answerChecker.OnWrongAnswered += InvokeAnsweredQuestionEvent;
    }

    private void OnDisable()
    {
        _answerChecker.OnRightAnswered -= AddScore;
        _answerChecker.OnRightAnswered -= InvokeAnsweredQuestionEvent;
        _answerChecker.OnWrongAnswered -= InvokeAnsweredQuestionEvent;
    }

    #endregion

    private void AddScore() => _score += _reward;

    private void InvokeAnsweredQuestionEvent() => OnAnsweredQuestion?.Invoke();
}