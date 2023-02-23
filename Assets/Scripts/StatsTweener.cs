using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StatsTweener : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _scaleTo = 1.5f;
    [SerializeField] private float _scaleDuration = 0.5f;
    [SerializeField] private float _scaleInterval = 0.1f;

    public void DoUpdateTweening(Text text)
    {
        var transform = text.transform;
        var parent = transform.parent;
        if (parent == null)
            throw new System.Exception("Answer counter has no parent! Add one");

        var originalScale = parent.localScale;

        DOTween.Sequence()
            .Append(transform.DOScale(_scaleTo, _scaleDuration))
            .AppendInterval(_scaleInterval)
            .Append(transform.DOScale(originalScale, _scaleDuration));
    }
}