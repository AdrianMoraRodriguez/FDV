using UnityEngine;

public class RemoveStartButton : MonoBehaviour
{
    void Start()
    {
        GameMode.OnGameModeChanged += OnModeChanged;
    }

    void OnModeChanged(bool isPlaying)
    {
        if (isPlaying)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
    void OnDestroy()
    {
        GameMode.OnGameModeChanged -= OnModeChanged;
    }
}