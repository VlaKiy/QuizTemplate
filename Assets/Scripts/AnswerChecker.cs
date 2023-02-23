using UnityEngine;
using System;

public class AnswerChecker : MonoBehaviour
{
    public event Action OnRightAnswered;
    public event Action OnWrongAnswered;

    public void CheckAnswer(Answer answer)
    {
        if (answer.IsCorrect)
            OnRightAnswered?.Invoke();
        else
            OnWrongAnswered?.Invoke();
    }
}