using DG.Tweening;
using UnityEngine;

public class HintEffect : MonoBehaviour
{
    [SerializeField] private Vector2 _endPosition;

    private RectTransform _rectTransform;
    private float _scaleTime = 0.15f, _moveTime = 0.35f;
    private Vector2 _startPos;
    private Sequence _sequence;

    public float AnimationTime => _scaleTime + _moveTime;

    public void Play()
    {
        CheckAnimation();

        if (_rectTransform == null)
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPos = _rectTransform.anchoredPosition;
        }
        gameObject.SetActive(true);

        _sequence.Append(_rectTransform.DOScale(Vector3.one, _scaleTime))
            .Append(_rectTransform.DOAnchorPos(_endPosition, _moveTime).SetDelay(_scaleTime))
            .Append(_rectTransform.DOScale(Vector2.zero, 0.1f).OnComplete(OnEnd).SetDelay(AnimationTime + 1f));
    }

    private void CheckAnimation()
    {
        if (_sequence != null && _sequence.IsPlaying())
        {
            _sequence.Kill();
            OnEnd();
        }
    }

    private void OnEnd()
    {
        gameObject.SetActive(false);
        _rectTransform.anchoredPosition = _startPos;
    }
}
