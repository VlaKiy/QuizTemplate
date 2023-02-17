using UnityEngine;
using UnityEngine.UI;
using UnityTools;

public class QuizView : MonoBehaviour
{
    [SerializeField] private Text _questionText;
    [SerializeField] private AnswerButton[] _buttons;

    public void SetupUI(Question currentQuestion)
    {
        SetupButtons(currentQuestion);
        SetupQuestionText(currentQuestion);
    }

    private void SetupButtons(Question currentQuestion)
    {
        var currentAnswers = currentQuestion.Answers;
        currentAnswers.TryShuffleArray<Answer>();

        for (var i = 0; i < _buttons.Length; i++)
            _buttons[i].Init(currentAnswers[i]);
    }

    private void SetupQuestionText(Question currentQuestion)
    {
        var text = currentQuestion.Text;
        _questionText.text = text;
    }
}
