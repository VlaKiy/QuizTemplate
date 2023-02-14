﻿using UnityEngine;

public class ScoreInfo : MonoBehaviour
{
    // Количество очков за выбранные ответы
    [SerializeField] private int _score;

    public int GetScore()
    {
        return _score;
    }

    public void AddScore(int count)
    {
        _score += count;
    }
}