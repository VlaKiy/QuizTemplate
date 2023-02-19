using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private AnswerChecker _answerChecker;

    private Answer _answer;

    public event Action OnInit;
    public event Action OnClicked;

    #region MonoBehaviour

    private void OnEnable()
    {
        _button.onClick.AddListener(CheckAnswer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    #endregion

    public void Init(Answer answer)
    {
        _answer = answer;
        _text.text = _answer.AnswerText;

        OnInit?.Invoke();
    }

    private void CheckAnswer()
    {
        _answerChecker.CheckAnswer(_answer);

        OnClicked?.Invoke();
    }
}
