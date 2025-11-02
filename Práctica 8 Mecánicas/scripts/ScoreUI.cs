using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("UI de puntuación")]
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    private void OnEnable()
    {
        GameEvents.OnCollectiblePicked += OnCollectiblePicked;
    }

    private void OnDisable()
    {
        GameEvents.OnCollectiblePicked -= OnCollectiblePicked;
    }

    private void OnCollectiblePicked(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + currentScore;
        }
    }
}
