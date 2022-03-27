using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommonCell : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] protected Color _colorCorrectPlace;
    [SerializeField] private Color _colorContainedLetter;
    [SerializeField] private Color _colorNotContainedLetter;
    [Header("")]
    [SerializeField] protected TextMeshProUGUI _text;
    [SerializeField] protected Image _background;

    public virtual void SetColor(ColorState colorState)
    {
        switch (colorState)
        {
            case ColorState.CORRECT:
                _background.color = _colorCorrectPlace;
                break;
            case ColorState.CONTAINED:
                _background.color = _colorContainedLetter;
                break;
            case ColorState.NOT_CONTAINED:
                _background.color = _colorNotContainedLetter;
                break;
        }    
    }
}

public enum ColorState
{
    CORRECT,
    CONTAINED,
    NOT_CONTAINED
}