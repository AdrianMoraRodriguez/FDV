using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    public int levelIndex; // 0–11
    public int levelID = 1;    // 1–12
    public string sceneName;

    [Header("UI")]
    public Button button;
    public GameObject lockIcon;
    public Image[] tartaIcons; // 3 por nivel

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        int totalTartas = LevelProgressManager.GetTotalTartas(12);
        Debug.Log("Tartas actuales: " + totalTartas);
        bool unlocked = LevelUnlockRules.IsLevelUnlocked(levelIndex, totalTartas);

        button.interactable = unlocked;
        lockIcon.SetActive(!unlocked);

        for (int i = 0; i < 3; i++)
        {
            tartaIcons[i].enabled =
                LevelProgressManager.HasTarta(levelID, i);
        }
    }

    public void NewGame()
    {
        LevelProgressManager.ResetAllProgress(12);
        GameEvents.OnProgressUpdated?.Invoke();
        Debug.Log("Tartas actuales: " + LevelProgressManager.GetTotalTartas(12));
    }


    public void LoadLevel()
    {
        if (!button.interactable) return;

        SceneManager.LoadScene(sceneName);
    }
}
