using UnityEngine;
using System.Collections.Generic;
using UnityTools;

public class Quiz : MonoBehaviour
{
    [SerializeField] private Question[] _questionsArray;

    private Queue<Question> _questions;
    private Question _currentQuestion;

    #region MonoBehaviour

    private void Awake()
    {
        InitFields();
    }

    #endregion

    private void InitFields()
    {
        _questionsArray.ShuffleArray();
        _questions = new(_questionsArray);
    }

    private void SetNextQuestion()
    {
        if (_currentQuestion != null)
            _currentQuestion.Answered -= SetNextQuestion;

        var question = GetNextQuestion();
        SetCurrentQuestion(question);
    }

    private void SetCurrentQuestion(Question question)
    {
        _currentQuestion = question;
        _currentQuestion.Answered += SetNextQuestion;
    }

    private Question GetNextQuestion()
    {
        return _questions.Dequeue();
    }
}