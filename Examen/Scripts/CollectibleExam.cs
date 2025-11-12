using UnityEngine;

public class CollectibleExam : MonoBehaviour
{
    public int pointsValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int totalPoints = pointsValue + TorchScoreBonus.CurrentBonus;
            GameEvents.CollectiblePicked(totalPoints);
            Destroy(gameObject);
        }
    }
}
