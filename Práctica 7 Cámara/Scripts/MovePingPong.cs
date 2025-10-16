using UnityEngine;

public class MovePingPong : MonoBehaviour {
  public float distancia = 3f;
  public float velocidad = 2f;
  private Vector3 origen;
  
  void Start() {
    origen = transform.position;
  }
  
  void Update() {
    float t = Mathf.PingPong(Time.time * velocidad, 1f);
    transform.position = origen + Vector3.right * Mathf.Lerp(-distancia, distancia, t);
  }
}
