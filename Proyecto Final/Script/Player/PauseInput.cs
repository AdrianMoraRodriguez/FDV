using UnityEngine;

public class PauseInput : MonoBehaviour
{
    bool isPaused = false;

  void OnEnable()
  {
    GameEvents.OnPauseRequested += () => isPaused = true;
    GameEvents.OnResumeRequested += () => isPaused = false;
  }

  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                GameEvents.OnPauseRequested?.Invoke();
            else
                GameEvents.OnResumeRequested?.Invoke();

            isPaused = !isPaused;
        }
    }
}
