using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    bool isDead = false;

    public void Die()
    {
        if (isDead) return;
        isDead = true;
        GameEvents.OnPlayerDied?.Invoke();
    }
}
