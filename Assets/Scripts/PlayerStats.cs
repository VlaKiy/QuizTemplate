using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AnswerChecker _answerChecker;
    [SerializeField] private PlayerStatsView _playerView;

    private int _score = 0;
    private int _reward = 1;

    public int Score => _score;

    public event Action OnAnsweredQuestion;

    #region MonoBehaviour

    private void OnEnable()
    {
        _answerChecker.OnRightAnswered += AddScore;
        _answerChecker.OnRightAnswered += InvokeAnsweredQuestionEvent;
        _answerChecker.OnWrongAnswered += UpdateWrongAnswersView;
        _answerChecker.OnWrongAnswered += InvokeAnsweredQuestionEvent;
    }

    private void OnDisable()
    {
        _answerChecker.OnRightAnswered -= AddScore;
        _answerChecker.OnRightAnswered -= InvokeAnsweredQuestionEvent;
        _answerChecker.OnWrongAnswered -= UpdateWrongAnswersView;
        _answerChecker.OnWrongAnswered -= InvokeAnsweredQuestionEvent;
    }

    #endregion

    private void AddScore()
    {
        _score += _reward;

        _playerView.UpdateRightAnswersConuter(_score);
    }

    private void UpdateWrongAnswersView() => _playerView.AddWrongAnswer();

    private void InvokeAnsweredQuestionEvent() => OnAnsweredQuestion?.Invoke();
}