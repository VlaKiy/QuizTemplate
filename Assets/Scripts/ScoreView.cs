using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public void ScoreAssigment(int scoreAnswer)
    {
        var scoreInfo = GameObject.Find("Canvas").GetComponent<Score>();
        scoreInfo.AddScore(scoreAnswer);

        var askCont = transform.parent;
        var nextAsk = askCont.GetComponent<Answer>().GetNextAsk();

        if (nextAsk != null)
        {
            nextAsk.SetActive(true);
            askCont.gameObject.SetActive(false);
        }
        // Здесь уже конец викторины, поэтому должно открываться окошко с результатами.
    }
}
