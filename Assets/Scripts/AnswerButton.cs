using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;

    private Answer _answer;

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
    }

    private void CheckAnswer()
    {
        if (_answer.IsCorrect)
        {
            HandleCorrectAnswer();
            return;
        }

        HandleWrongAnswer();
    }

    private void HandleCorrectAnswer()
    {

    }

    private void HandleWrongAnswer()
    {

    }
}
