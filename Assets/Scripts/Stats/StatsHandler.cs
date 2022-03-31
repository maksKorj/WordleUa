using System.Collections;
using UnityEngine;

public class StatsHandler : MonoBehaviour
{
    private static StatsHandler _instance;
    public static StatsHandler Instance => _instance;

    private int _gameAmount, _winPercentage, _maxWinStreak, _currentWinStreak;
    private int[] _attempts = new int[6];

    #region Properties
    public int GameAmount => _gameAmount;
    public int WinPercentage => _winPercentage;
    public int MaxWinStreak => _maxWinStreak;
    public int CurrentWinStreak => _currentWinStreak;
    public int[] Attempts => _attempts;
    #endregion

    private void Awake()
    {
        SetUpSingleton();
        GetStartData();
    }

    private void SetUpSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void GetStartData()
    {
        _gameAmount = StatsSaver.LoadGameAmount();
        _winPercentage = StatsSaver.LoadPercentage();
        _currentWinStreak = StatsSaver.LoadCurrentWinStreak();
        _maxWinStreak = StatsSaver.LoadMaxWinStreak();

        _attempts = StatsSaver.LoadAttempts();
    }

    public void UpdateData(int winAttempt)
    {
        _gameAmount++;

        if(winAttempt != 0)
        {
            _attempts[winAttempt - 1]++;
            _currentWinStreak++;

            if (_currentWinStreak >= _maxWinStreak)
                _maxWinStreak++;
        }
        else
        {
            _currentWinStreak = 0;
        }

        int winAmount = GetWinGameAmount();
        _winPercentage = (winAmount != 0) ? (winAmount * 100 /  _gameAmount) : 0;

        SaveData();
    }

    public int GetWinGameAmount()
    {
        int amount = 0;

        for (int i = 0; i < _attempts.Length; i++)
            amount += _attempts[i];

        return amount;
    }

    private void SaveData()
    {
        StatsSaver.SaveGameAmount(_gameAmount);
        StatsSaver.SavePercentage(_winPercentage);
        StatsSaver.SaveCurrentWinStreak(_currentWinStreak);
        StatsSaver.SaveMaxWinStreak(_maxWinStreak);

        StatsSaver.SaveAttempts(_attempts);
    }
}
