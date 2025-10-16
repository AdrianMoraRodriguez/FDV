using UnityEngine;

public class CameraHotkeys : MonoBehaviour {
  [SerializeField] private GameObject vcamA;
  [SerializeField] private GameObject vcamB;
  public KeyCode keyA = KeyCode.Alpha1;
  public KeyCode keyB = KeyCode.Alpha2;
  public KeyCode keyToggle = KeyCode.Tab;
  void Start() {
    if (!vcamA || !vcamB) {
      Debug.LogError("[CameraHotkeys] Asigna vcamA y vcamB en el Inspector.");
      return;
    }
    SetActiveExclusive(vcamA, vcamB, true);
  }
  void Update() {
    if (!vcamA || !vcamB) return;
    if (Input.GetKeyDown(keyA)) {
      SetActiveExclusive(vcamA, vcamB, true);
    }
    if (Input.GetKeyDown(keyB)) {
      SetActiveExclusive(vcamA, vcamB, false);
    }
    if (Input.GetKeyDown(keyToggle)) {
      SetActiveExclusive(vcamA, vcamB, !vcamA.activeSelf);
    }
  }
  private void SetActiveExclusive(GameObject a, GameObject b, bool aOn) {
    a.SetActive(aOn);
    b.SetActive(!aOn);
  }
}
