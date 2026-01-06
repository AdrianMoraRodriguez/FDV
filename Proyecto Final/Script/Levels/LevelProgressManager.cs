using UnityEngine;

public static class LevelProgressManager
{
    static string Key(int levelID) => $"LEVEL_{levelID}_TARTAS";

    public static void SaveTarta(int levelID, int tartaIndex)
    {
        int mask = PlayerPrefs.GetInt(Key(levelID), 0);
        mask |= (1 << tartaIndex);
        PlayerPrefs.SetInt(Key(levelID), mask);
        PlayerPrefs.Save();
    }

    public static bool HasTarta(int levelID, int tartaIndex)
    {
        int mask = PlayerPrefs.GetInt(Key(levelID), 0);
        return (mask & (1 << tartaIndex)) != 0;
    }

    public static int GetCollectedCount(int levelID)
    {
        int mask = PlayerPrefs.GetInt(Key(levelID), 0);
        int count = 0;

        for (int i = 0; i < 3; i++)
            if ((mask & (1 << i)) != 0)
                count++;

        return count;
    }

    public static int GetTotalTartas(int totalLevels)
    {
        int total = 0;

        for (int levelID = 1; levelID <= totalLevels; levelID++)
        {
            total += GetCollectedCount(levelID);
        }

        return total;
    }

    public static void ResetAllProgress(int totalLevels)
    {
        for (int levelID = 1; levelID <= totalLevels; levelID++)
        {
            PlayerPrefs.DeleteKey(Key(levelID));
        }
    
        PlayerPrefs.Save();
    }

    public static void ResetLevel(int levelID)
    {
        PlayerPrefs.DeleteKey(Key(levelID));
    }
}
