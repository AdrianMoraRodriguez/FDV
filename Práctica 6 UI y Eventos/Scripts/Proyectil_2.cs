using UnityEngine;
using System.Collections;

public class Proyectil_2 : MonoBehaviour {
  private Rigidbody2D rb;

  public float speed = 7f;
  public float lifeTime = 2f;

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Start(){
    if (!rb) rb = GetComponent<Rigidbody2D>();
    if (rb) rb.bodyType = RigidbodyType2D.Kinematic;
  }


  public void shoot(bool right = true) {
    Debug.Log("Disparando " + (right ? "a la derecha en shoot" : "a la izquierda en shoot"));
    StartCoroutine(FireRoutine(right));
  }

  private IEnumerator FireRoutine(bool right = true) {
    Debug.Log("Entro en FireRoutine");
    if (rb) {
      Debug.Log(right ? "Disparando a la derecha en FireRoutine" : "Disparando a la izquierda en FireRoutine");
      rb.bodyType = RigidbodyType2D.Dynamic;
      Vector2 dir = right ? Vector2.right : Vector2.left;
      rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }
    yield return new WaitForSeconds(lifeTime);
    Destroy(gameObject);
  }
    
    void OnBecameInvisible() {
      if (this != null) Destroy(gameObject);
    }
}
