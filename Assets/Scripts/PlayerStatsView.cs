using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsView : MonoBehaviour
{
    private const string DefaultStatsText = "0";

    [Header("Components")]
    [SerializeField] private StatsTweener _tweener;

    [Header("Answers' counters texts")]
    [SerializeField] private Text _rightAnswersCounter;
    [SerializeField] private Text _wrongAnswersCounter;

    private int _wrongAnswersAmount = 0;

    #region MonoBehaviour

    private void Awake()
    {
        _rightAnswersCounter.text = _wrongAnswersCounter.text = DefaultStatsText;
    }

    #endregion

    public void UpdateRightAnswersConuter(int score)
    {
        _rightAnswersCounter.text = score.ToString();

        _tweener.DoUpdateTweening(_rightAnswersCounter);
    }

    public void AddWrongAnswer()
    {
        _wrongAnswersAmount++;

        _wrongAnswersCounter.text = _wrongAnswersAmount.ToString();

        _tweener.DoUpdateTweening(_wrongAnswersCounter);
    }
}