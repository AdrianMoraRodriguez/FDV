using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  private Rigidbody2D rb;
  public float normalSpeed = 5f;
  public float turboSpeed = 10f;
  private Animator animator;
  private SpriteRenderer spriteRenderer;
  public Transform firePoint;
  private bool turboOn = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    if (rb == null) {
      Debug.LogError("Rigidbody2D component not found on the GameObject.");
    }
  }

  void FixedUpdate()
  {
    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveX, moveY);
    if (movement[0] != 0)
    {
      animator.SetBool("IsRunning", true);
    }
    else
    {
      animator.SetBool("IsRunning", false);
    }
    if (movement[0] < 0)
    {
      spriteRenderer.flipX = true;
      firePoint.localPosition = new Vector3(-0.111f, -0.105f, 0);
    }
    else if (movement[0] > 0)
    {
      spriteRenderer.flipX = false;
      firePoint.localPosition = new Vector3(0.09f, -0.105f, 0);
    }
    float speed = turboOn ? turboSpeed : normalSpeed;
    Debug.Log("Speed: " + speed);
    rb.AddForce(movement * speed);
  }
  
  public void SetTurbo() {
    turboOn = !turboOn;
  }
}
