using UnityEngine;

public class CarrusselManagerSize : MonoBehaviour {
  public GameObject[] cubos;
  public Vector3 newSize;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
        
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.K)) {
      cambiarTamanos();
    }
  }

  void cambiarTamanos() {
    for (int i = 0; i < cubos.Length; i++) {
      cubos[i].transform.localScale = newSize;
    }
  }
}
