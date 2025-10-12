using UnityEngine;
using System.Collections;
using System;

public class PlayerShooter : MonoBehaviour {
  public Proyectil_2 projectilePrefab;
  public PlayerNotifier notifier;
  public Transform firePoint;
  public Animator animator;
  public float spawnDelay = 0.5f;

  void Start() {
    if (!notifier) notifier = FindFirstObjectByType<PlayerNotifier>();
    if (notifier != null)
    {
      notifier.OnPlayerActivated += Disparar;
    }
    else
    {
      Debug.LogError("PlayerNotifier not found in the scene.");
    }
  }
  
  public void Disparar() {
    if (animator) animator.SetTrigger("Dispara");
    StartCoroutine(DispararConRetraso());
  }
  private System.Collections.IEnumerator DispararConRetraso() {
    yield return new WaitForSeconds(spawnDelay);
    Proyectil_2 proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    if (firePoint.localPosition.x < 0) {
      Debug.Log("Disparando a la izquierda en PlayerShooter");
      proj.shoot(false);
    }
    if (firePoint.localPosition.x > 0) {
      Debug.Log("Disparando a la derecha en PlayerShooter");
      proj.shoot(true);
    }
  }
}
