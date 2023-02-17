using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTools;

public class Quiz : MonoBehaviour
{
    [SerializeField] private Text _questionText;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Question[] _questionsArray;
    [SerializeField] private AnswerButton[] _buttons;
 
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

        // Refactor: View class
        SetupUI();
    }

    private void SetupUI()
    {
        SetupButtons();
        SetupQuestionText();
    }

    private void SetupButtons()
    {
        var currentAnswers = _currentQuestion.Answers;
        currentAnswers.TryShuffleArray<Answer>();

        for (var i = 0; i < _buttons.Length; i++)
            _buttons[i].Init(currentAnswers[i]);
    }

    private void SetupQuestionText()
    {
        var text = _currentQuestion.Text;
        _questionText.text = text;
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