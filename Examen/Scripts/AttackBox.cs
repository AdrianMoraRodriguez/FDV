using UnityEngine;
using System.Collections.Generic;

public class AttackBox : MonoBehaviour
{
    private readonly List<Bandit> enemiesInRange = new List<Bandit>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Bandit bandit = other.GetComponent<Bandit>();
            if (bandit != null && !enemiesInRange.Contains(bandit))
            {
                enemiesInRange.Add(bandit);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Bandit bandit = other.GetComponent<Bandit>();
            if (bandit != null && enemiesInRange.Contains(bandit))
            {
                enemiesInRange.Remove(bandit);
            }
        }
    }

    public void PerformAttack()
    {
        foreach (Bandit bandit in enemiesInRange)
        {
            if (bandit != null && bandit.gameObject.activeInHierarchy)
            {
                bandit.Kill();
            }
        }
    }
}
