using UnityEngine;
using UnityEngine.UI;

public class AnswerInfo : MonoBehaviour
{
    // Следующий контейнер с вопросами и ответами, который нужно будет показать.
    public GameObject nextAsk;

    // Вопрос
    public string ask;

    // Список ответов, которые есть
    public string[] answers;

    // Префабы кнопок с ответами
    public GameObject[] prefabs;

    // Запускать ли скрипт
    public bool isStart = false;

    // Для работы с массивом answers
    private int answerCount = 0; 

    private void Start()
    {
        if (isStart)
        {
            // Добавляем UI в окно игры.
            MakeUI(prefabs[0], -1, 145);
            MakeUI(prefabs[1], -1, 27);
            MakeUI(prefabs[2], -268, -56);
            MakeUI(prefabs[3], 266, -56);
            MakeUI(prefabs[4], -268, -190);
            MakeUI(prefabs[5], 266, -190);
        }
    }

    // Добавляет UI, принимает Префаб какого-то из элементов UI, его позицию X и Y
    public void MakeUI(GameObject prefab, int posX, int posY)
    {
        // Добавляем в игру UI
        var p = Instantiate(prefab);
        // Берем его компонент RectTransform
        var rt = p.GetComponent<RectTransform>();
        // Задаем родителем askCont
        p.transform.SetParent(transform);
        // Создаем позицию, в которой должен появиться UI элемент
        p.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);

        if (posX == -1) // Если поставлю posX -1 тогда позиция UI по X будет по середине, Y - заданным числом
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, posY);
        }
        else // Иначе UI появится по строго заданной позиции
        {
            rt.anchoredPosition = new Vector2(posX, posY);
        }
        
        // Делаем величину по умолчанию
        p.transform.localScale = new Vector3(1f, 1f, 1f);

        // Функция, которая записывает текст в кнопки и в вопрос.
        MakeText(p);
    }

    void MakeText(GameObject p)
    {
        // Находим компонент Text в переданном UI
        var pText = p.GetComponent<Text>();

        if (pText)  // Если компонент Text есть, то записываем в него вопрос.
        {
            pText.text = ask;
        }
        else if(p.GetComponentInChildren<Text>()) // Если компонент Text лежит в кнопке, то присваеваем ей текст из массива.
        {
            pText = p.GetComponentInChildren<Text>();
            pText.text = answers[answerCount];
            // Нужен, чтобы каждый раз добавлять следующий текст из массива.
            answerCount++;
        }
        else
        {
            // Ничего не делаем
        }
    }
}
