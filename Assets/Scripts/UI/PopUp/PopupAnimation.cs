using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupAnimation : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _rectTransform;

    public void Open()
    {
        EnableObject();
        OpenAmimation();
    }

    public void Open(Action doActionBeforeOpen)
    {
        doActionBeforeOpen();
        Open();
    }

    public void OpenWithoutAnimation()
    {
        EnableObject();
        _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, 0.9f);
        _rectTransform.localScale = Vector3.one;
    }

    private void EnableObject()
    {
        _rectTransform.localScale = Vector3.zero;

        _background.enabled = true;
        gameObject.SetActive(true);
    }

    protected virtual void OpenAmimation()
    {
        _background.DOFade(0.9f, 0.3f).SetEase(Ease.InCubic);
        _rectTransform.DOScale(Vector2.one, 0.4f).SetEase(Ease.InCubic);
    }

    public void Close()
    {
        _background.DOFade(0f, 0.3f).SetEase(Ease.InCubic);
        _rectTransform.DOScale(Vector2.zero, 0.4f).SetEase(Ease.OutCubic).OnComplete(Disable);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
        _background.enabled = false;
    }
}
