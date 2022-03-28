using UnityEngine;
using DG.Tweening;

public class Border : ColorChanger
{
    [SerializeField] private Color _activeColor;
    [SerializeField] private RectTransform _rectTransform;
    private Color _defaultColor;

    private void Awake()
        => _defaultColor = _background.color;

    public void SetActiveColor()
        => _rectTransform.DOPunchScale(Vector3.one / 8, 0.1f, 1).OnComplete(() => _background.color = _activeColor);

    public void SetDefaultColor() => _background.color = _defaultColor;
}
