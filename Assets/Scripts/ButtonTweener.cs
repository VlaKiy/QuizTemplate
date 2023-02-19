using UnityEngine;
using DG.Tweening;

public class ButtonTweener : MonoBehaviour
{
    [SerializeField] private AnswerButton _button;
    [SerializeField] private float _showDuration = 0.6f;
    [SerializeField] private float _hideDuration = 0.6f;

    private float _hideEndPosition = -10f;

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
            .AppendInterval(1f)
            .AppendCallback(() => transform.position = originalPosition)
            .AppendCallback(() => transform.localScale = Vector3.zero)
            .Append(transform.DOScale(Vector3.one, _showDuration));
    }
}