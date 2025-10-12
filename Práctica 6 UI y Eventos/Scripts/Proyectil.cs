using UnityEngine;

public class Proyectil : MonoBehaviour {

  private SpriteRenderer spriteRenderer;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer == null) {
      Debug.LogError("SpriteRenderer component not found on the GameObject.");
    } else {
      spriteRenderer.enabled = false;
    }    
  }

  public void Activar() {
    if (spriteRenderer != null) {
      spriteRenderer.enabled = true;
    }
  }
}
