using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTools;

public class Quiz : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private QuizView _quizView;
    [SerializeField] private Question[] _questionsArray;
 
    private Queue<Question> _questions;
    private Question _currentQuestion;

    public event Action OnQuizEnded;

    #region MonoBehaviour

    private void OnEnable()
    {
        _playerStats.OnAnsweredQuestion += SetNextQuestion;
    }

    private void OnDisable()
    {
        _playerStats.OnAnsweredQuestion -= SetNextQuestion;
    }

    #endregion

    private void StartQuiz()
    {
        InitFields();
        SetNextQuestion();
    }

    private void InitFields()
    {
        _questionsArray.TryShuffleArray<Question>();
        _questions = new Queue<Question>(_questionsArray);
    }

    private void SetNextQuestion()
    {
        if (TryGetNextQuestion(out var question))
            SetCurrentQuestion(question);
        else
            OnQuizEnded?.Invoke();
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