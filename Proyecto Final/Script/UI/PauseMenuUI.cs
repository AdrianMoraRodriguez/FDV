using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] string menuSceneName = "MainMenu";

    void OnEnable()
    {
        GameEvents.OnPauseRequested += Show;
        GameEvents.OnResumeRequested += Hide;
    }

    void OnDisable()
    {
        GameEvents.OnPauseRequested -= Show;
        GameEvents.OnResumeRequested -= Hide;
    }

    void Show()
    {
        pausePanel.SetActive(true);
    }

    void Hide()
    {
        pausePanel.SetActive(false);
    }

    public void Continue()
    {
        GameEvents.OnResumeRequested?.Invoke();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
