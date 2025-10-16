using UnityEngine;

public class MoveCircular : MonoBehaviour {
  public float radio = 2f;
  public float rpm = 0.2f;
  private Vector3 centro;

  void Start() {
    centro = transform.position;
  }
  
  void Update() {
    float ang = Time.time * rpm * 2f * Mathf.PI;
    transform.position = centro + new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0f) * radio;
  }
}
