using UnityEngine;

public class CuboDeColores : MonoBehaviour {
  public Color color1 = Color.red;
  public float size = 1;
  public bool changeScaleInRuntime = false;
  public bool changePositionInRuntime = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    changeColor();
  }

  // Update is called once per frame
  void Update() {
    if (changeScaleInRuntime) {
      changeScale();
    }
    if (changePositionInRuntime) {
      changePosition();
    }
  }

  void changeColor() {
    GameObject cube = this.gameObject;
    cube.transform.localScale = new Vector3(size, size, size);
    Renderer cubeRenderer = cube.GetComponent<Renderer>();
    cubeRenderer.material.color = color1;

  }

  void changeScale() {
    float scale = 1 + Mathf.PingPong(Time.time, 1);
    transform.localScale = new Vector3(scale, scale, scale);
  }

  void changePosition() {
    float y = Mathf.PingPong(Time.time, 3);
    transform.position = new Vector3(0, y, 0);
  }
}
