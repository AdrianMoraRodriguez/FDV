using UnityEngine;
using Unity.Cinemachine;

public class PlayerCameraZoom : MonoBehaviour {
  public CinemachineCamera vcam;
  public float zoomSpeed = 1f;
  public float minZoom = 5f;
  public float maxZoom = 20f;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    if (vcam == null) {
      vcam = FindFirstObjectByType<CinemachineCamera>();
    }
  }

    // Update is called once per frame
  void Update()
  {
    if (vcam != null)
    {
      int dir = 0;
      if (Input.GetKey(KeyCode.W)) dir -= 1;
      if (Input.GetKey(KeyCode.S)) dir += 1;
      if (dir != 0) {
        float size = vcam.Lens.OrthographicSize;
        size += dir * zoomSpeed * Time.deltaTime;
        size = Mathf.Clamp(size, minZoom, maxZoom);
        vcam.Lens.OrthographicSize = size;
      }
    }
  }
}
