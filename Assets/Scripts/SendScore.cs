using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SendScore : MonoBehaviour
{
    public void ScoreAssigment()
    {
        EnableButtons();

        var scoreInfo = GameObject.Find("Canvas").GetComponent<ScoreInfo>();
        var rightAnswer = gameObject.GetComponentInParent<AnswerInfo>().GetRightAnswer();
        var buttonImage = GetComponent<Image>();
        var answerName = "Answer" + rightAnswer;

        if (gameObject.name == answerName)
        {
            StartCoroutine(Waiter());
            buttonImage.color = Color.green;
            scoreInfo.AddScore(1);
        }
        else
        {
            StartCoroutine(Waiter());
            buttonImage.color = Color.red;
        }
    }

    private void GoNextAnswer()
    {
        var askCont = transform.parent;
        var nextAsk = askCont.GetComponent<AnswerInfo>().GetNextAsk();

        if (nextAsk != null)
        {
            nextAsk.SetActive(true);
            askCont.gameObject.SetActive(false);
        }
    }

    private void EnableButtons()
    {
        var askCont = transform.parent;

        for (int i = 1; i <= 4; i++)
        {
            var button = askCont.transform.Find("Answer" + i).GetComponent<Button>();
            button.interactable = false;
        }
    }

    IEnumerator Waiter()
    {
        var timer = 1;

        for (int i = 1; i <= timer; i++)
        {
            yield return new WaitForSeconds(1);

            if (i == timer)
            {
                GoNextAnswer();
            }
        }
    }
}
