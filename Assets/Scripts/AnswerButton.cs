using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AnswerChecker _answerChecker;

    [Header("This Button")]
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _originalButton;

    private Answer _answer;

    public event Action OnInit;

    #region MonoBehaviour

    private void OnEnable()
    {
        _originalButton.onClick.AddListener(CheckAnswer);
    }

    private void OnDisable()
    {
        _originalButton.onClick.RemoveAllListeners();
    }

    #endregion

    public void SetupAnswer(Answer answer)
    {
        _answer = answer;
        _buttonText.text = _answer.AnswerText;

        OnInit?.Invoke();
    }

    private void CheckAnswer()
    {
        _answerChecker.CheckAnswer(_answer);
    }
}