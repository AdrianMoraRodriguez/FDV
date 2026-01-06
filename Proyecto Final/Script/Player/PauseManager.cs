using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    void OnEnable()
    {
        GameEvents.OnPauseRequested += Pause;
        GameEvents.OnResumeRequested += Resume;
    }

    void OnDisable()
    {
        GameEvents.OnPauseRequested -= Pause;
        GameEvents.OnResumeRequested -= Resume;
    }

    void Pause()
    {
        if (IsPaused) return;

        IsPaused = true;
        Time.timeScale = 0f;
    }

    void Resume()
    {
        if (!IsPaused) return;

        IsPaused = false;
        Time.timeScale = 1f;
    }
}
