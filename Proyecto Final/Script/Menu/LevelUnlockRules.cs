public static class LevelUnlockRules
{
    public static bool IsLevelUnlocked(int levelIndex, int totalTartas)
    {
        if (levelIndex < 4) return true;          // 0–3
        if (levelIndex < 8) return totalTartas >= 8;   // 4–7
        if (levelIndex < 12) return totalTartas >= 16; // 8–11

        return false;
    }
}
