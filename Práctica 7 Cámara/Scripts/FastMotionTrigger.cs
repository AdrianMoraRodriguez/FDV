using UnityEngine;

public class FastMotionTrigger : MonoBehaviour {
  [SerializeField] private GameObject fastCam;    
  [SerializeField] private GameObject normalCam;
  [SerializeField] private float fastScale = 1.8f;
  [SerializeField] private float fastDuration = 3f;
  private bool isFastActive = false;
  void Start() {
    if (fastCam) fastCam.SetActive(false);
    if (normalCam) normalCam.SetActive(true);
  }
  
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player") && !isFastActive) {
      StartCoroutine(ActivateFastMotion());
    }
  }
  
  private System.Collections.IEnumerator ActivateFastMotion(){
    isFastActive = true;
    if (normalCam && fastCam) {
      normalCam.SetActive(false);
      fastCam.SetActive(true);
    }
    Time.timeScale = fastScale;
    Time.fixedDeltaTime = 0.02f * Time.timeScale;
    yield return new WaitForSecondsRealtime(fastDuration);
    Time.timeScale = 1f;
    Time.fixedDeltaTime = 0.02f;
    if (normalCam && fastCam) {
      fastCam.SetActive(false);
      normalCam.SetActive(true);
    }
    isFastActive = false;
  }
}
