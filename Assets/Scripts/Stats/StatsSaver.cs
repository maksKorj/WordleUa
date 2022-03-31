using UnityEngine;

public class StatsSaver : MonoBehaviour
{
    private const string _gameAmountPath = "GameAmount";
    private const string _percentagePath = "Percentage";
    private const string _currentWinStreakPath = "CurrentWinStreak";
    private const string _maxWinStreakPath = "MaxWinStreak";
    private const string _attemptPath = "Attempt";

    public static int LoadGameAmount() => LoadSave(_gameAmountPath);
    public static void SaveGameAmount(int gameAmount) => PlayerPrefs.SetInt(_gameAmountPath, gameAmount);

    public static int LoadPercentage() => LoadSave(_percentagePath);
    public static void SavePercentage(int percentage) => PlayerPrefs.SetInt(_percentagePath, percentage);

    public static int LoadCurrentWinStreak() => LoadSave(_currentWinStreakPath);
    public static void SaveCurrentWinStreak(int currentWinStreak) => PlayerPrefs.SetInt(_currentWinStreakPath, currentWinStreak);

    public static int LoadMaxWinStreak() => LoadSave(_maxWinStreakPath);
    public static void SaveMaxWinStreak(int maxWinStreak) => PlayerPrefs.SetInt(_maxWinStreakPath, maxWinStreak);

    public static int[] LoadAttempts()
    {
        int[] attempts = new int[6];

        for(int i = 0; i < attempts.Length; i++)
            attempts[i] = LoadSave($"{_attemptPath}_{i}");

        return attempts;
    }

    public static void SaveAttempts(int[] attempts)
    {
        for (int i = 0; i < attempts.Length; i++)
            PlayerPrefs.SetInt($"{_attemptPath}_{i}", attempts[i]);
    }

    private static int LoadSave(string path)
    {
        if (PlayerPrefs.HasKey(path))
            return PlayerPrefs.GetInt(path);
        else
            return 0;
    }
}
