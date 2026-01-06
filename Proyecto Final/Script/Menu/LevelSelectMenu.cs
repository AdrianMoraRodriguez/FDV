using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    LevelButtonUI[] buttons;

    void OnEnable()
    {
        buttons = FindObjectsOfType<LevelButtonUI>();
        GameEvents.OnProgressUpdated += RefreshAll;
    }

    void OnDisable()
    {
        GameEvents.OnProgressUpdated -= RefreshAll;
    }

    void Start()
    {
        RefreshAll();
    }

    void RefreshAll()
    {
        foreach (var b in buttons)
            b.Refresh();
    }
}
