using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerInfo : MonoBehaviour
{
    // Следующий контейнер с вопросами и ответами, который нужно будет показать.
    [SerializeField] private GameObject _nextAsk;

    // Вопрос
    [SerializeField] private string _ask;

    // Список ответов, которые есть
    [SerializeField] private string[] _answers;

    // Префабы UI
    [SerializeField] private GameObject[] _UIPrefabs;

    // Запускать ли скрипт
    private bool _isStart = true;

    // Для работы с массивом answers
    private int _answerCount = 0;

    private void Start()
    {
        if (_isStart)
        {
            // Добавляем UI в окно игры.
            MakeUI(_UIPrefabs[0], new Vector2(0, 145), true);
            MakeUI(_UIPrefabs[1], new Vector2(0, 27), true);
            MakeUI(_UIPrefabs[2], new Vector2(-268, -56));
            MakeUI(_UIPrefabs[3], new Vector2(266, -56));
            MakeUI(_UIPrefabs[4], new Vector2(-268, -190));
            MakeUI(_UIPrefabs[5], new Vector2(266, -190));
        }
    }

    // Добавляет UI, принимает Префаб какого-то из элементов UI, его позицию X и Y, будет ли объект по середине по X
    private void MakeUI(GameObject prefab, Vector2 pos, bool isMiddleX = false)
    {
        // Добавляем в игру UI
        var UIprefab = Instantiate(prefab);
        // Берем его компонент RectTransform
        var rt = UIprefab.GetComponent<RectTransform>();
        // Задаем родителем askCont
        UIprefab.transform.SetParent(transform);
        // Создаем позицию, в которой должен появиться UI элемент
        UIprefab.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);

        if (isMiddleX) // Если isMiddle = true значит позиция по X будет середина
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, pos.y);
        }
        else // Иначе UI появится по строго заданной позиции
        {
            rt.anchoredPosition = new Vector2(pos.x, pos.y);
        }

        // Делаем величину по умолчанию
        UIprefab.transform.localScale = new Vector3(1f, 1f, 1f);

        // Функция, которая записывает текст в кнопки и в вопрос.
        MakeText(UIprefab);
    }

    private void MakeText(GameObject UIprefab)
    {
        // Находим компонент Text в переданном UI
        var UIprefabText = UIprefab.GetComponent<Text>();

        if (UIprefabText)  // Если компонент Text есть, то записываем в него вопрос.
        {
            UIprefabText.text = _ask;
        }
        else if(UIprefab.GetComponentInChildren<Text>()) // Если компонент Text лежит в кнопке, то присваеваем ей текст из массива.
        {
            UIprefabText = UIprefab.GetComponentInChildren<Text>();
            UIprefabText.text = _answers[_answerCount];
            // Нужен, чтобы каждый раз добавлять следующий текст из массива.
            _answerCount++;
        }
    }

    public GameObject GetNextAsk()
    {
        return _nextAsk;
    }
}
