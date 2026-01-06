using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] float waitBeforeReturn = 2f;
    [SerializeField] string menuSceneName = "MainMenu";

    bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;
        triggered = true;
        GameEvents.OnLevelFinished?.Invoke();
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(waitBeforeReturn);
        SceneManager.LoadScene(menuSceneName);
    }
}
