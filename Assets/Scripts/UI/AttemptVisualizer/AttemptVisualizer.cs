using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttemptVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalAmountDisplay;
    [SerializeField] private Slider _slider;

    public void UpdateData(int amount, float percentage)
    {
        _totalAmountDisplay.text = amount.ToString();
        _slider.value = percentage;
    }
}
