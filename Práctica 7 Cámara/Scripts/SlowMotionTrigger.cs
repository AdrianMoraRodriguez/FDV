using UnityEngine;

public class SlowMotionTrigger : MonoBehaviour
{
  [SerializeField] private GameObject slowCam;   
  [SerializeField] private GameObject normalCam; 
  [SerializeField] private float slowScale = 0.3f;   
  [SerializeField] private float slowDuration = 3f;  
  private bool isSlowActive = false;
  private void Start() {
    if (slowCam) slowCam.SetActive(false);
    if (normalCam) normalCam.SetActive(true);
  }
  
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player") && !isSlowActive) {
      StartCoroutine(ActivateSlowMotion());
    }
  }
  
  private System.Collections.IEnumerator ActivateSlowMotion(){
    isSlowActive = true;
    if (normalCam && slowCam) {
      normalCam.SetActive(false);
      slowCam.SetActive(true);
    }
    Time.timeScale = slowScale;
    Time.fixedDeltaTime = 0.02f * Time.timeScale;
    yield return new WaitForSecondsRealtime(slowDuration);
    Time.timeScale = 1f;
    Time.fixedDeltaTime = 0.02f;
    if (normalCam && slowCam){
      slowCam.SetActive(false);
      normalCam.SetActive(true);
    }
    isSlowActive = false;
  }
}
