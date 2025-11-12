using UnityEngine;
using System.Linq;

public class PlatformBonus : MonoBehaviour
{
    public int bonusIncrease = 1;
    private bool triggered = false; // para que solo cuente una vez por plataforma

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    if (enemy.activeInHierarchy)
                    {
                        enemy.SetActive(false);
                        break;
                    }
                }
            }
            TorchScoreBonus.CurrentBonus += bonusIncrease;
            Debug.Log("Bonus de antorchas aumentado a: " + TorchScoreBonus.CurrentBonus);
            triggered = true;
        }
    }
}
