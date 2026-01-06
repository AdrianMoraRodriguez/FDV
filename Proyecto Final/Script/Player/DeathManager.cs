using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0f;

    void OnEnable()
    {
        GameEvents.OnPlayerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerDied -= OnPlayerDied;
    }

    void OnPlayerDied()
    {
        if (reloadDelay > 0f)
            StartCoroutine(ReloadWithDelay());
        else
            ReloadScene();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    System.Collections.IEnumerator ReloadWithDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        ReloadScene();
    }
}
