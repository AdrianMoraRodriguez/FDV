using UnityEngine;

public class FarAway : MonoBehaviour {
  public float activationDistance = 10f;
  private float totalDistance = 0f;
  private Vector3 lastPosition;
  private Animator animator;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    lastPosition = transform.position;
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    float distanceThisFrame = Vector3.Distance(transform.position, lastPosition);
    totalDistance = distanceThisFrame;
    Debug.Log("Distance this frame: " + distanceThisFrame);
    if (totalDistance >= activationDistance)
    {
      animator.SetBool("FarAway", true);
    }
    else
    {
      animator.SetBool("FarAway", false);
    }    
  }
}
