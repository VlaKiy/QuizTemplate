using System.Collections.Generic;
using UnityEngine;
using UnityTools;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private Question[] _questionsArray;
    [SerializeField] private AnswerButton[] _buttons;
    [SerializeField] private Text _questionText;
    [SerializeField] private PlayerStats _playerStats;
 
    private Queue<Question> _questions;
    private Question _currentQuestion;

    #region MonoBehaviour

    private void OnEnable()
    {
        _playerStats.OnLost += LoseGame;
    }

    private void OnDisable()
    {
        _playerStats.OnLost -= LoseGame;
    }

    private void Awake()
    {
        InitFields();
    }

    #endregion

    private void InitFields()
    {
        _questionsArray.TryShuffleArray<Question>();
        _questions = new Queue<Question>(_questionsArray);

        SetNextQuestion();
    }

    private void LoseGame()
    {

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

    private Question GetNextQuestion()
    {
        return _questions.Dequeue();
    }
}