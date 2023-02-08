using UnityEngine;

public class SendScore : MonoBehaviour
{
    public void ScoreAssigment(int scoreAnswer)
    {
        // Подключаем скрипт, который хранит количество очков.
        var scoreInfo = GameObject.Find("Canvas").GetComponent<ScoreInfo>();
        // Добавляем очки за определенный ответ. 1 кнопка - 1 балл, 2 кнопка - 2 балла и т.д.
        scoreInfo.score += scoreAnswer;

        // Находим askCont и в скрипте берем переменную со следющим контейнером с вопросами и ответами
        var askCont = transform.parent;
        var nextAsk = askCont.GetComponent<AnswerInfo>().nextAsk;

        // Если следующий вопрос есть, то включаем видимость следующего контейнера и выключаем текущий.
        if (nextAsk != null)
        {
            nextAsk.SetActive(true);
            askCont.gameObject.SetActive(false);
        }
        else
        {
            // Здесь уже конец викторины, поэтому должно открываться окошко с результатами.
        }
    }
}
