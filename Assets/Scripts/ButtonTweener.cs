using UnityEngine;
using DG.Tweening;

public class ButtonTweener : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AnswerButton _button;

    [Header("Settings")]
    [SerializeField] private float _showDuration = 0.6f;
    [SerializeField] private float _hideDuration = 0.6f;

    private readonly float _hideEndPosition = -10f;
    private readonly float _intervalBetweenShowAndHide = 1f;

    #region MonoBehaviour

    private void OnEnable()
    {
        _button.OnInit += UpdateButtons;
    }

    private void OnDisable()
    {
        _button.OnInit -= UpdateButtons;
    }

    #endregion

    private void UpdateButtons()
    {
        var originalPosition = transform.position;
        transform.DOScale(Vector3.one, _showDuration);

        DOTween.Sequence()
            .Append(transform.DOMoveY(_hideEndPosition, _hideDuration))
            .AppendInterval(_intervalBetweenShowAndHide)
            .AppendCallback(() => transform.position = originalPosition)
            .AppendCallback(() => transform.localScale = Vector3.zero)
            .Append(transform.DOScale(Vector3.one, _showDuration));
    }
}