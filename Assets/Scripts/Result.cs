using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private ResultView _resultView;

    public void Calculate(int score)
    {
        if (score >= 0)
            _resultView.ShowFirst();
        else if (score > 5)
            _resultView.ShowSecond();
        else if (score > 10)
            _resultView.ShowThird();
        else if (score > 15)
            _resultView.ShowForth();
        else
            throw new System.Exception("Unknown result condition!");
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
}