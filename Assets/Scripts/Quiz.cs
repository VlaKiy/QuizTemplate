using System.Collections.Generic;
using UnityEngine;
using UnityTools;

public class Quiz : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Result _result;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private QuizView _quizView;

    [Header("Content")]
    [SerializeField] private Question[] _questionsArray;
 
    private Queue<Question> _questions;
    private Question _currentQuestion;

    #region MonoBehaviour

    private void OnEnable()
    {
        _playerStats.OnAnsweredQuestion += TrySetNextQuestion;
    }

    private void OnDisable()
    {
        _playerStats.OnAnsweredQuestion -= TrySetNextQuestion;
    }

    private void Awake()
    {
        InitFields();
        TrySetNextQuestion();
    }

    #endregion

    private void InitFields()
    {
        _questionsArray.TryShuffleArray<Question>();
        _questions = new Queue<Question>(_questionsArray);
    }

    private void TrySetNextQuestion()
    {
        if (TryGetNextQuestion(out var question))
        {
            SetCurrentQuestion(question);
        }
        else
        {
            gameObject.SetActive(false);

            Application.ExternalCall("ShowAd");
            var score = _playerStats.Score;
            _result.Calculate(score);
            _result.Activate();
        }
    }

    private void SetCurrentQuestion(Question question)
    {
        _currentQuestion = question;

        _quizView.SetupUI(_currentQuestion);
    }

    private bool TryGetNextQuestion(out Question question)
    {
        question = null;

        if (_questions.Count == 0)
            return false;

        question = _questions.Dequeue();
        return true;
    }
}