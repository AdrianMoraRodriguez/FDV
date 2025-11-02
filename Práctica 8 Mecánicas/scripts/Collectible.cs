using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointsValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.CollectiblePicked(pointsValue);
            Destroy(gameObject);
        }
    }
}
