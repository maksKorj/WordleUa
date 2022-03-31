using UnityEngine;
using TMPro;

public class PopupStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameAmountDisplay;
    [SerializeField] private TextMeshProUGUI _winPercentageDisplay;
    [SerializeField] private TextMeshProUGUI _currentWinStreakDisplay;
    [SerializeField] private TextMeshProUGUI _maxWinStreakDisplay;
    [Header("")]
    [SerializeField] protected AttemptVisualizer[] _attemptVisualizers;

    private PopupAnimation _popupAnimation;

    public void Open()
    {
        if (_popupAnimation == null)
            _popupAnimation = GetComponent<PopupAnimation>();

        _popupAnimation.Open(DoActionBeforeOpen);
    }

    private void DoActionBeforeOpen()
    {
        _gameAmountDisplay.text = StatsHandler.Instance.GameAmount.ToString();
        _winPercentageDisplay.text = $"{StatsHandler.Instance.WinPercentage}%";
        _currentWinStreakDisplay.text = StatsHandler.Instance.CurrentWinStreak.ToString();
        _maxWinStreakDisplay.text = StatsHandler.Instance.MaxWinStreak.ToString();

        ProcessAttempts();
    }

    private void ProcessAttempts()
    {
        int winAmount = StatsHandler.Instance.GetWinGameAmount();
        
        for(int i = 0; i < _attemptVisualizers.Length; i++)
        {
            _attemptVisualizers[i].UpdateData(StatsHandler.Instance.Attempts[i],
                GetPercentage(StatsHandler.Instance.Attempts[i], winAmount));
        }
    }

    private int GetPercentage(int attemptAmount, int totalWinAmount)
    {
        if (totalWinAmount == 0)
            return 17;

        int percentage = (attemptAmount * 100) / totalWinAmount;

        return (percentage <= 17) ? 17 : percentage;
    }
}
