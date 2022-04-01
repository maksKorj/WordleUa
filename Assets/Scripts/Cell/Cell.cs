using UnityEngine;
using DG.Tweening;
using TMPro;

public class Cell : ColorChanger
{
    [SerializeField] private Border _border;
    [SerializeField] private TextMeshProUGUI _text;
    [Header("")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private float _flipTime = 0.5f;

    private ColorState _colorState;

    public KeyButton KeyButton { get; private set; }
    public float FlipTime => _flipTime;
    public float ShakeTime => _flipTime;
    
    public char? Letter
    {
        get
        {
            if (_text.text == null || _text.text == "")
                return null;

            return _text.text[0];
        }
    }

    public bool IsPainted { get; private set; }

    public void SetLetter(char letter, KeyButton keyButton)
    {
        _text.text = letter.ToString().ToUpper();
        _border.SetActiveColor();
        KeyButton = keyButton;
    }

    public void Clear()
    {
        _text.text = null;
        _border.SetDefaultColor();
    }

    public void Flip(ColorState colorState)
    {
        IsPainted = true;
        _colorState = colorState;

        _rectTransform.DORotate(_rotationVector, _flipTime, RotateMode.FastBeyond360).OnComplete(FlipBack);
    }

    private void FlipBack()
    {
        SetColor(_colorState);
        _rectTransform.DORotate(Vector3.zero, _flipTime, RotateMode.FastBeyond360);
    }

    public override void SetColor(ColorState colorState)
    {
        KeyButton.SetColor(colorState);
        _border.SetColor(colorState);

        base.SetColor(colorState);
    }

    public void Shake()
        => _rectTransform.DOShakeAnchorPos(_flipTime, 5f, 10, 45);
}
