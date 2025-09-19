using UnityEngine;

public class CarrusselManager : MonoBehaviour {
  public GameObject[] cubos;
  public Vector3 newSize;
  public Color color;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
  
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      cambiarColores();
    }
    if (Input.GetKeyDown(KeyCode.K)) {
      cambiarTamanos();
    }
  }

  void cambiarColores() {
    for (int i = 0; i < cubos.Length; i++) {
      Renderer rend = cubos[i].GetComponent<Renderer>();
      rend.material.color = color;
    }
  }

  void cambiarTamanos() {
    for (int i = 0; i < cubos.Length; i++) {
      cubos[i].transform.localScale = newSize;
    }
  }
}
