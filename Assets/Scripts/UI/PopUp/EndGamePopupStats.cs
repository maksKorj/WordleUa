
public class EndGamePopupStats : PopupStats
{
    public void Open(int winAttempt)
    {
        if (winAttempt != 0)
            (_attemptVisualizers[winAttempt - 1] as EndGameAttemptVisualizer).Select();

        StatsHandler.Instance.UpdateData(winAttempt);
        Open();
    }
}
