using System;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour {
  // Clase tag
  public string tagActivator = "Activator";
  public event Action OnPlayerActivated;
  
  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(tagActivator)) {
      Debug.Log("PlayerNotifier: Player has activated an activator.");
      OnPlayerActivated?.Invoke();
    }
  }
}
