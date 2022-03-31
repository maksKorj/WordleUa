using UnityEngine;
using UnityEngine.UI;

public class EndGameAttemptVisualizer : AttemptVisualizer
{
    [SerializeField] private Image _fillAmount;
    [SerializeField] private Color _selectColor;

    public void Select() => _fillAmount.color = _selectColor;
}
