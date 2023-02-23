using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz/Question")]
public class Question : ScriptableObject
{
    private const int AnswerMaximumAmount = 4;

    [Header("Settings")]
    [SerializeField] private string _text;
    [SerializeField] private Answer[] _answers;

    public string Text => _text;
    public Answer[] Answers => _answers;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_answers.Length > AnswerMaximumAmount)
            throw new Exception("This Amount of answers is not too high!");
    }

    #endregion
}