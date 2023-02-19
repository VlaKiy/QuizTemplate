using UnityEngine;
using DG.Tweening;

public class UITweener : MonoBehaviour
{
    [SerializeField] private float _showDuration = 0.6f;
    [SerializeField] private float _hideDuration = 0.6f;

    private float _hideEndPosition = -10f;

    private void Awake()
    {
        Show();
    }

    public void Show()
    {
        transform.localScale = Vector3.zero;

        transform.DOScale(Vector3.one, _showDuration);
    }

    public void Hide()
    {
        transform.DOMoveY(-10f, _hideDuration);
    }
}
