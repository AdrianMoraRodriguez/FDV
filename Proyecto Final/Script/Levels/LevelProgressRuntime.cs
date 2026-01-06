using System.Collections.Generic;

public static class LevelProgressRuntime
{
    static Dictionary<int, HashSet<int>> collectedThisRun = new Dictionary<int, HashSet<int>>();

    public static void RegisterTarta(int levelID, int tartaIndex)
    {
        if (!collectedThisRun.ContainsKey(levelID))
            collectedThisRun[levelID] = new HashSet<int>();

        collectedThisRun[levelID].Add(tartaIndex);
    }

    public static IEnumerable<int> GetCollectedTartas(int levelID)
    {
        if (!collectedThisRun.ContainsKey(levelID))
            yield break;

        foreach (var t in collectedThisRun[levelID])
            yield return t;
    }

    public static void ClearLevel(int levelID)
    {
        collectedThisRun.Remove(levelID);
    }
}
