using UnityEngine;

public class LevelProgressListener : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnLevelFinished += SaveLevelProgress;
    }

    void OnDisable()
    {
        GameEvents.OnLevelFinished -= SaveLevelProgress;
    }

    void SaveLevelProgress()
    {
        int levelID = FindObjectOfType<LevelIdentifier>().levelID;
        foreach (int tartaIndex in LevelProgressRuntime.GetCollectedTartas(levelID))
        {
            LevelProgressManager.SaveTarta(levelID, tartaIndex);
        }
        LevelProgressRuntime.ClearLevel(levelID);
        GameEvents.OnProgressUpdated?.Invoke();
    }
}
