using UnityEngine;
using System;

public class Question : MonoBehaviour
{
    public const int AnswerMaximumAmount = 4;

    [SerializeField] private string _text;
    [SerializeField] private Answer[] _answers;

    public string Text => _text;
    public Answer[] Answers => _answers;

    public event Action Answered;

    #region MonoBehaviour

    private void Awake()
    {
        if (_answers.Length > AnswerMaximumAmount)
            throw new Exception("This Amount of answers is not too high!");
    }

    #endregion
}