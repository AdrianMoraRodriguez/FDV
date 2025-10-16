using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitchOnTrigger : MonoBehaviour {
  [SerializeField] private CinemachineCamera confinedCam;
  [SerializeField] private CinemachineCamera freeCam;
  [SerializeField] private CinemachineBrain brain;
  [SerializeField] private CinemachineBlendDefinition.Styles blendStyle = CinemachineBlendDefinition.Styles.EaseInOut;
  [SerializeField] private float blendTime = 1.5f;
  [SerializeField] private string playerTag = "Player";
  private bool confinedActive = true;
  private void Start() {
    if (!brain) {
      brain = Camera.main.GetComponent<CinemachineBrain>();
    }
    if (confinedCam) confinedCam.Priority = 15;
    if (freeCam) freeCam.Priority = 10;
  }
  
  private void OnTriggerEnter2D(Collider2D other) {
    if (!other.CompareTag(playerTag)) return;
    ToggleCamera();
  }

  private void ToggleCamera() {
    confinedActive = !confinedActive;
    if (confinedCam && freeCam) {
      confinedCam.Priority = confinedActive ? 15 : 10;
      freeCam.Priority     = confinedActive ? 10 : 15;
    }
    if (brain != null) {
      brain.DefaultBlend = new CinemachineBlendDefinition(blendStyle, blendTime);
    }
  }
}
