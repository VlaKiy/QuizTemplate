using UnityEngine;

public class SendScore : MonoBehaviour
{
    public void ScoreAssigment(int scoreAnswer)
    {
        var scoreInfo = GameObject.Find("Canvas").GetComponent<ScoreInfo>();
        scoreInfo.AddScore(scoreAnswer);

        var askCont = transform.parent;
        var nextAsk = askCont.GetComponent<AnswerInfo>().GetNextAsk();

        if (nextAsk != null)
        {
            nextAsk.SetActive(true);
            askCont.gameObject.SetActive(false);
        }
        // Здесь уже конец викторины, поэтому должно открываться окошко с результатами.
    }
}
